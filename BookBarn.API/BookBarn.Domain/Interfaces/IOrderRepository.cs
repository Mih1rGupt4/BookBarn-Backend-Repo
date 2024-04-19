using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBarn.Domain.Entities;


namespace BookBarn.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Order GetOrderById(int orderId);
        void AddOrder(int orderId, OrderItem order);
        void UpdateOrder(int orderId,OrderItem order);
        void RemoveOrder(int orderId, int ItemId);
    }

}
