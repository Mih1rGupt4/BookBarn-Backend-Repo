using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Entities
{
    public class Wishlist
    {
        [Key]
        public int WishlistId { get; set; } 
        public int UserId { get; set; }    
        public int BookID {  get; set; }
        public virtual Book TheBook { get; set; }

    }
}
