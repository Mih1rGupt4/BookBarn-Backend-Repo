using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookBarn.API.Models.OrderEntities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Address ShippingAddress { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
        public Usertemp User { get; set; }
        public List<Booktemp> Books { get; set; }
        public OrderStatus Status { get; set; }
    }

}