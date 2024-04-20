using BookBarn.Domain.Entities;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Data.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly BookBarnDbContext _dbContext;

        public ShoppingCartRepository()
        {
            _dbContext = new BookBarnDbContext();
        }
        public ShoppingCart AddCartItem(int cartId, CartItem item)
        {   
            var shoppingCart = _dbContext.ShoppingCarts.Find(cartId);
            if (shoppingCart != null)
            {
                item.ShoppingCartID = cartId;
                _dbContext.CartItems.Add(item);
               
            }
            else
            {
                shoppingCart = new ShoppingCart { ShoppingCartID = cartId };
                _dbContext.ShoppingCarts.Add(shoppingCart);
                item.ShoppingCartID = cartId;
                _dbContext.CartItems.Add(item);
                //update userid when creating a cart
                //shoppingCart.UserID = 

            }
            shoppingCart.TotalPrice += item.Price * item.Quantity;
            _dbContext.SaveChanges();
            return shoppingCart;
        }

        public ShoppingCart GetShoppingCartById(int cartId)
        {
            return _dbContext.ShoppingCarts.Find(cartId);

        }

        public ShoppingCart RemoveCartItem(int cartId, int itemId)
        {
            var cartItem = _dbContext.CartItems.FirstOrDefault(ci => ci.ShoppingCartID == cartId && ci.CartItemID == itemId);
            if (cartItem != null)
            {
                _dbContext.CartItems.Remove(cartItem);
                var shoppingCart = GetShoppingCartById(cartId);
                shoppingCart.TotalPrice-=cartItem.Price*cartItem.Quantity;
                _dbContext.SaveChanges();
                return shoppingCart;
            }
            else
            {
                throw new InvalidOperationException($"Cart item with ID {itemId} not found in shopping cart with ID {cartId}.");
            }
        }

        public ShoppingCart UpdateCartItemQuantity(int cartItemId, int quantity)
        {
            var existingCartItem = _dbContext.CartItems.Find(cartItemId);
            if (existingCartItem == null)
            {
                throw new InvalidOperationException("Cart item not found");
            }

            var existingCart = existingCartItem.ShoppingCart;

            existingCart.TotalPrice -= existingCartItem.Price * existingCartItem.Quantity;
            Console.WriteLine("total price before: " + existingCart.TotalPrice);

            existingCartItem.Quantity = quantity;

            existingCart.TotalPrice += existingCartItem.Price * existingCartItem.Quantity;
            Console.WriteLine("total price after: " + existingCart.TotalPrice);

            _dbContext.SaveChanges();

            return existingCart;
        }

    }
}
