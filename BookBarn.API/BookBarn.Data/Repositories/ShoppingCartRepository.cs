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
        public ShoppingCart AddCartItem(int userId, CartItem item)
        {
            ShoppingCart shoppingCart = _dbContext.ShoppingCarts
                                                   .Include(cart => cart.CartItems)
                                                   .FirstOrDefault(cart => cart.UserID == userId);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart
                {
                    UserID = userId,
                    CartItems = new List<CartItem>(),
                    TotalPrice = 0
                };
                _dbContext.ShoppingCarts.Add(shoppingCart);
                _dbContext.SaveChanges(); 
            }

            item.ShoppingCartID = shoppingCart.ShoppingCartID; 
            _dbContext.CartItems.Add(item);
            shoppingCart.TotalPrice += item.Price * item.Quantity;
            _dbContext.SaveChanges();

            return shoppingCart;
        }
        public ShoppingCart GetShoppingCartById(int cartId)
        {
            return _dbContext.ShoppingCarts.FirstOrDefault(c => c.UserID==cartId);

        }

        public ShoppingCart RemoveCartItem(int cartId, int itemId)
        {
            var shoppingCart = _dbContext.ShoppingCarts
                                 .Include(cart => cart.CartItems)
                                 .FirstOrDefault(cart => cart.UserID == cartId);

            if (shoppingCart == null)
            {
                throw new InvalidOperationException($"No shopping cart found for User ID {cartId}.");
            }

           
            var cartItem = shoppingCart.CartItems.FirstOrDefault(ci => ci.CartItemID == itemId);

            if (cartItem != null)
            {
                _dbContext.CartItems.Remove(cartItem);
                shoppingCart.TotalPrice -= cartItem.Price * cartItem.Quantity;
                _dbContext.SaveChanges();
                return shoppingCart;
            }
            else
            {
                throw new InvalidOperationException($"Cart item with ID {itemId} not found in shopping cart for User ID {cartId}.");
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

        public void Clear(int id)
        {
            var cart= _dbContext.ShoppingCarts.FirstOrDefault(c => c.UserID == id);
            cart.TotalPrice = 0;
            var cartItemsToRemove = cart.CartItems.ToList();
            _dbContext.CartItems.RemoveRange(cartItemsToRemove);
            _dbContext.ShoppingCarts.Remove(cart);
            _dbContext.SaveChanges();
        }

    }
}
