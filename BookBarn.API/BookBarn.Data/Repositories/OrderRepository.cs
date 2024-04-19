using BookBarn.Domain.Entities;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        BookBarnDbContext db;

        public OrderRepository()
        {
            db = new BookBarnDbContext();
        }

        public List<Order> GetAllOrders()
        {
            return db.Orders.ToList();
        }

        public Order GetOrder(int id)
        {
            return db.Orders.Find(id);
        }

        public List<Order> GetAllOrdersForUser(string userId)
        {
            return db.Orders.Where(o => o.UserID == userId).ToList();
        }

        public void AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void UpdateOrderStatus(Order order, Order newOrder)
        {
            order.Status = newOrder.Status;
            db.SaveChanges();
        }
    }
}
