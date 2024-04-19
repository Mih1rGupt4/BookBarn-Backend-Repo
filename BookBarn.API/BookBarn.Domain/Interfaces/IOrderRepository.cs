using BookBarn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();

        Order GetOrder(int id);

        List<Order> GetAllOrdersForUser(string userId);

        void AddOrder(Order order);

        void UpdateOrderStatus(Order order, Order newOrder);
    }
}
