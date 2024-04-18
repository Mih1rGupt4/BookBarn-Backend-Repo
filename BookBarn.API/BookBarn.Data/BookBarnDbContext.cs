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
        public BookBarnDbContext() : base("")
        {
            
        }


    }
}
