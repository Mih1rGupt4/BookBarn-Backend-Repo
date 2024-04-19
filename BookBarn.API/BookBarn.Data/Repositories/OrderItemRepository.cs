using BookBarn.Domain.Entities;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Data.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private BookBarnDbContext db;
        OrderItemRepository(BookBarnDbContext dbContext)
        {
            db = dbContext;
        }
        public OrderItem GetOrderItemById(int itemId)
        {
            return db.OrderItems.Where(orditem => orditem.OrderItemID == itemId).FirstOrDefault();
        }
    }
}
