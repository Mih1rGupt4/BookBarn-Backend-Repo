using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Entities
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }

        public virtual Book Book { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
