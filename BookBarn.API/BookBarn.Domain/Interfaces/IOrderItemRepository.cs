using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBarn.Domain.Entities;


namespace BookBarn.Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        OrderItem GetOrderItemById(int itemId);

    }
}
