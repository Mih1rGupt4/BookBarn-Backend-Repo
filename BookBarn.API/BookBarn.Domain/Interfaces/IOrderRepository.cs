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
        

        Order GetOrder(int id);

        void AddOrder(Order order);

        void UpdateOrderStatus(Order order, Order newOrder);




        // ---------------------------------------
        // new methodes
        // ---------------------------------------



         List<Order> GetAll();


         List<Order> GetAllByUserId(string userId);


         List<Order> GetAllActive();


         List<Order> GetActiveOrdersByUserId(string userId);


         List<Order> GetAllCompleted();


         List<Order> GetCompletedOrdersByUserId(string userId);



         List<Order> GetAllCancelled();


         List<Order> GetCancelledOrdersByUserId(string userId);
       

    }
}
