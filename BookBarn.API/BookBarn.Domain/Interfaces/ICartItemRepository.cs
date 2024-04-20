using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBarn.Domain.Entities;

namespace BookBarn.Domain.Interfaces
{
    public interface ICartItemRepository
    {
        CartItem GetCartItemById(int itemId);
        //void UpdateCartItem(CartItem item);

    }
}
