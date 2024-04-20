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


        public Order GetOrder(int id)
        {
            return db.Orders.Find(id);
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






       // ---------------------------------------
       // new methodes
       // ---------------------------------------

        public List<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public List<Order> GetAllByUserId(string userId) 
        {
            return db.Orders.Where(o => o.UserID == userId).ToList();
        }


        public List<Order> GetAllActive()
        {
            return db.Orders.Where(o => 
             o.Status != OrderStatus.ReturnCompleted &&
             o.Status != OrderStatus.ReplacedCompleted &&
             o.Status != OrderStatus.Cancelled &&
             o.Status != OrderStatus.Delivered).ToList();
        }

        public List<Order> GetActiveOrdersByUserId(string userId)
        {
            return db.Orders.Where(o => 
            o.UserID == userId &&
            o.Status != OrderStatus.ReturnCompleted &&
            o.Status != OrderStatus.ReplacedCompleted &&
            o.Status != OrderStatus.Cancelled &&
            o.Status != OrderStatus.Delivered).ToList();
        }

        public List<Order> GetAllCompleted()
        {
            return db.Orders.Where(o => o.Status == OrderStatus.Delivered).ToList();
        }

        public List<Order> GetCompletedOrdersByUserId(string userId)
        {
            return db.Orders.Where(o => o.UserID == userId && o.Status == OrderStatus.Delivered).ToList();
        }


        public List<Order> GetAllCancelled()
        {
            return db.Orders.Where(o=>o.Status == OrderStatus.Cancelled).ToList();
        }

        public List<Order> GetCancelledOrdersByUserId(string userId)
        {
            return db.Orders.Where(o => o.UserID == userId && o.Status == OrderStatus.Cancelled).ToList();
        }

    }
}
