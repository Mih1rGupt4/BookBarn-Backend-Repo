using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }

        public string UserID { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }

        public double TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }
       
        public Address ShippingAddress { get; set; }

        public PaymentDetails PaymentDetails {  get; set; }
        public OrderStatus Status { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }
}
