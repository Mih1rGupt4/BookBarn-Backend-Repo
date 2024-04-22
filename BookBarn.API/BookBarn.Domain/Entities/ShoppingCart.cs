using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Entities
{
    public class ShoppingCart
    {
        public int ShoppingCartID { get; set; }

        public int UserID { get; set; }

        public virtual List<CartItem> CartItems { get; set; }

        public double TotalPrice { get; set; }
    }
}
