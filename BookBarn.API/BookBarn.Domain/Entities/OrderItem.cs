﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Entities
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }

        public int BookID { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int OrderID { get; set; }

        public virtual Order Order { get; set; }
    }
}