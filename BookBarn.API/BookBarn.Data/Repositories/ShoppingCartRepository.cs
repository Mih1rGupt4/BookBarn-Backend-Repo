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
        private BookBarnDbContext _dbContext;
        ShoppingCartRepository(BookBarnDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
