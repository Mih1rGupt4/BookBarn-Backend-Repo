using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBarn.Domain.Entities;

namespace BookBarn.Domain.Interfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetShoppingCartById(int cartId);
        void AddCartItem(int cartId, CartItem item);
        void RemoveCartItem(int cartId, int itemId);
    }
}
