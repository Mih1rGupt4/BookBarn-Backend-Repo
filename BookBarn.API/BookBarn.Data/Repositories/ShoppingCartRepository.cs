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
        public void AddCartItem(int cartId, CartItem item)
        {
            var shoppingCart = _dbContext.ShoppingCarts.Find(cartId);
            if (shoppingCart != null)
            {
                item.ShoppingCartID = cartId;
                _dbContext.CartItems.Add(item);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException($"Shopping cart with ID {cartId} not found.");
            }
        }

        public ShoppingCart GetShoppingCartById(int cartId)
        {
            return _dbContext.ShoppingCarts.Find(cartId);

        }

        public void RemoveCartItem(int cartId, int itemId)
        {
            var cartItem = _dbContext.CartItems.FirstOrDefault(ci => ci.ShoppingCartID == cartId && ci.CartItemID == itemId);
            if (cartItem != null)
            {
                _dbContext.CartItems.Remove(cartItem);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException($"Cart item with ID {itemId} not found in shopping cart with ID {cartId}.");
            }
        }

        public ShoppingCart UpdateCartItem(int cartId, CartItem item)
        {
            var existingCart = _dbContext.ShoppingCarts.Find(cartId);
            if (existingCart == null)
            {
                throw new InvalidOperationException("Shopping cart not found");
            }


            var existingCartItem = existingCart.CartItems.FirstOrDefault(ci => ci.CartItemID == item.CartItemID);
            if (existingCartItem == null)
            {
                throw new InvalidOperationException("Cart item not found in the shopping cart");
            }
            existingCart.TotalPrice -= existingCartItem.Price * existingCartItem.Quantity;
            Console.WriteLine("total price before :" + existingCart.TotalPrice);

            existingCartItem.Quantity = item.Quantity;

          
            existingCart.TotalPrice += item.Price * existingCartItem.Quantity;
            Console.WriteLine("total price after :" + existingCart.TotalPrice);

            _dbContext.SaveChanges();

            return existingCart;
        }

    }
}
