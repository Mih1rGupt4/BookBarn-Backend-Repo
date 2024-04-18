using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Entities
{
    public class CartItem
    {
        public int CartItemID { get; set; }

        public int BookID { get; set; } 

        public int Quantity { get; set; }

        public double Price { get; set; }

        public int ShoppingCartID { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }

}
