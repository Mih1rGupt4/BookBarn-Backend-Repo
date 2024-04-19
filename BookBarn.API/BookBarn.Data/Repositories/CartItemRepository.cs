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
    public class CartItemRepository : ICartItemRepository
    {
        private readonly BookBarnDbContext db;
        CartItemRepository(BookBarnDbContext dbContext)
        {
            db  = dbContext;
        }

        public CartItem GetCartItemById(int itemId)
        {
            return db.CartItems.Find(itemId);

        }

        public void UpdateCartItem(CartItem item)
        {
            var existingItem = db.CartItems.Find(item.CartItemID);
            if (existingItem != null)
            {
                existingItem.Quantity = item.Quantity;
                db.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Item not found");

            }

        }
    }
}
