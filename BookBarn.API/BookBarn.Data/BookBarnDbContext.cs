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
       
        public DbSet<Wishlist> Wishlists { get; set; }
    }
}
