using BookBarn.Domain.Entities;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Data.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private List<CartItem> items;

        public ShoppingCartRepository()
        {
            items = new List<CartItem>();
        }
        public void AddCartItem(int cartId, CartItem item)
        {
            
        }

        public ShoppingCart GetShoppingCartById(int cartId)
        {
            
        }

        public void RemoveCartItem(int cartId, int itemId)
        {
            
        }
    }
}
