using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Entities
{
    public class Wishlist
    {
        [Key]
        public int WishlistId { get; set; } 
        [Required]
        public int UserId { get; set; }
        [Required]
        public virtual Book Book { get; set; }  
    }
}
