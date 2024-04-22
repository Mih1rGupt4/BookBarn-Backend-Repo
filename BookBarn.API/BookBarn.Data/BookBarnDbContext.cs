using BookBarn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Data
{
    public class BookBarnDbContext : DbContext
    {
        public BookBarnDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<ReviewCumRating> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set;}
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ReviewCumRating> ReviewCumRatings { get; set; }
    }
}
