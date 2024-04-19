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
    public class OrderRepository : IOrderRepository
    {
        private BookBarnDbContext db;
        OrderRepository(BookBarnDbContext dbContext)
        {
            db = dbContext;
        }


        public void AddOrder(int orderId, OrderItem order)
        {
            var getOrder = db.Orders.Find(orderId);
            if (getOrder != null)
            {
                getOrder.OrderItems.Add(order);
                db.SaveChanges();
            }
        }

        public Order GetOrderById(int orderId)
        {
            return db.Orders.Find(orderId);
        }

        public void RemoveOrder(int orderId, int ItemId)
        {
            var getOrder = db.Orders.Find(orderId);
            if (getOrder != null)
            {
                var orderItemToRemove = getOrder.OrderItems.Where(item => item.OrderItemID == ItemId).FirstOrDefault();
                if (orderItemToRemove != null)
                {
                    getOrder.OrderItems.Remove(orderItemToRemove);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateOrder(int orderId, OrderItem order)
        {
            var getOrder = db.Orders.Find(orderId);
            if (getOrder != null)
            {
                var existingOrderItem = getOrder.OrderItems.FirstOrDefault(item => item.OrderItemID == order.OrderItemID);
                if (existingOrderItem != null)
                {
                    existingOrderItem.Quantity = order.Quantity;
                    db.Entry(getOrder).State = EntityState.Modified;

                    db.SaveChanges();
                }

            }
        }
    }
}
