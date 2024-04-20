using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Entities
{
    public class WishList
    {
        [Key]
        public int WishlistId { get; set; }
        
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BookID {  get; set; }
        public virtual Book Book { get; set; }
    }
}
