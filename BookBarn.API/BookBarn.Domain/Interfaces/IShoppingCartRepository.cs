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
        ShoppingCart AddCartItem(int cartId, CartItem item);
        ShoppingCart RemoveCartItem(int cartId, int itemId);
        ShoppingCart UpdateCartItemQuantity(int cartId, int quantity);

    }
}
