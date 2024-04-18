using BookBarn.Domain.Entities;
using System.Web.Http.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace BookBarn.API.Controllers
{
    public class OrderController : ApiController
    {
        private List<Order> orders = new List<Order>();
        public OrderController()
        {


            // Order 1
            Order order1 = new Order
            {
                OrderID = 1,
                UserID = "user123",
                OrderItems = new List<OrderItem>
    {
        new OrderItem { OrderItemID = 1, BookID = 101, Quantity = 2, Price = 25.50m, OrderID = 1 },
        new OrderItem { OrderItemID = 2, BookID = 102, Quantity = 1, Price = 30.25m, OrderID = 1 }
    },
                TotalPrice = 81.25,
                OrderDate = DateTime.Now.AddDays(-10),
                ShippingAddress = new Address
                {
                    AddressID = 1,
                    AddressLine1 = "123 Main St",
                    City = "Anytown",
                    State = "NY",
                    PostalCode = "12345",
                    Country = "USA"
                },
                PaymentDetails = new PaymentDetails { PaymentDetailsID = 1, Amount = 81.25, TransactionId = "trans123", PaymentSource = "Credit Card" },
                Status = OrderStatus.Delivered
            };

            orders.Add(order1);

            // Order 2
            Order order2 = new Order
            {
                OrderID = 2,
                UserID = "user456",
                OrderItems = new List<OrderItem>
    {
        new OrderItem { OrderItemID = 3, BookID = 103, Quantity = 3, Price = 20.00m, OrderID = 2 },
        new OrderItem { OrderItemID = 4, BookID = 104, Quantity = 1, Price = 15.75m, OrderID = 2 }
    },
                TotalPrice = 75.75,
                OrderDate = DateTime.Now.AddDays(-15),
                ShippingAddress = new Address
                {
                    AddressID = 2,
                    AddressLine1 = "456 Oak St",
                    City = "Sometown",
                    State = "CA",
                    PostalCode = "54321",
                    Country = "USA"
                },
                PaymentDetails = new PaymentDetails { PaymentDetailsID = 2, Amount = 75.75, TransactionId = "trans456", PaymentSource = "PayPal" },
                Status = OrderStatus.ReturnRequested
            };
            orders.Add(order2);



            // Order 3
            Order order3 = new Order
            {
                OrderID = 3,
                UserID = "user789",
                OrderItems = new List<OrderItem>
    {
        new OrderItem { OrderItemID = 5, BookID = 105, Quantity = 1, Price = 10.50m, OrderID = 3 },
        new OrderItem { OrderItemID = 6, BookID = 106, Quantity = 2, Price = 15.25m, OrderID = 3 }
    },
                TotalPrice = 41.00,
                OrderDate = DateTime.Now.AddDays(-20),
                ShippingAddress = new Address
                {
                    AddressID = 3,
                    AddressLine1 = "789 Pine St",
                    City = "Smallville",
                    State = "TX",
                    PostalCode = "67890",
                    Country = "USA"
                },
                PaymentDetails = new PaymentDetails { PaymentDetailsID = 3, Amount = 41.00, TransactionId = "trans789", PaymentSource = "Credit Card" },
                Status = OrderStatus.Dispatched
            };
            orders.Add(order3);

            // Order 4
            Order order4 = new Order
            {
                OrderID = 4,
                UserID = "user101",
                OrderItems = new List<OrderItem>
    {
        new OrderItem { OrderItemID = 7, BookID = 107, Quantity = 1, Price = 12.75m, OrderID = 4 },
        new OrderItem { OrderItemID = 8, BookID = 108, Quantity = 3, Price = 8.50m, OrderID = 4 }
    },
                TotalPrice = 38.25,
                OrderDate = DateTime.Now.AddDays(-25),
                ShippingAddress = new Address
                {
                    AddressID = 4,
                    AddressLine1 = "101 Elm St",
                    City = "Metroville",
                    State = "FL",
                    PostalCode = "45678",
                    Country = "USA"
                },
                PaymentDetails = new PaymentDetails { PaymentDetailsID = 4, Amount = 38.25, TransactionId = "trans101", PaymentSource = "PayPal" },
                Status = OrderStatus.Packed
            };
            orders.Add(order4);


        }



        // get
        // api/order/
        // get all orders (only for the admin) 
        public IHttpActionResult GetAllOrders()
        {
            return Ok(orders); // if found then return 200 with data
        }


        // get
        // api/order/{id}
        // get all orders by user
        [Route("api/order/{id}")]
        public IHttpActionResult GetOrdersById(string id)
        {
           var alluserorders=orders.Where(o=>o.UserID==id).ToList();
            if(alluserorders==null || alluserorders.Count()==0)
            {
                return BadRequest();
            }
            return Ok(alluserorders); // if found then return 200 with data
        }


        // post
        // api/order
        // to post the order
        [HttpPost]
        public IHttpActionResult PostAddOrder(Order order)
        {

            if (order == null)
            {
                return BadRequest("Missing data to patch");
            }
            orders.Add(order);
            return Created("location",orders.Count()); // if found then return 200 with data
        }


        // patch
        // api/order/{id}
        // edit the status for admin to change the status
        //[HttpPatch]
        // public IHttpActionResult PatchEditStatus(int id, [FromBody]Delta<Order>order)
        [HttpPatch]
        [Route("api/order/{id}")]

        public IHttpActionResult PatchEditStatus(int id,[FromBody]Order order)
        {


            if (order == null)
            {
                return BadRequest("Missing data to patch");
            }

            var existingOrder = orders.FirstOrDefault(o => o.OrderID == id);


            if (existingOrder == null)
            {

                return BadRequest("canot find the order with this id");

            }

            existingOrder.UserID = order.UserID;
            existingOrder.OrderItems = order.OrderItems;
            existingOrder.TotalPrice = order.TotalPrice;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.ShippingAddress = order.ShippingAddress;
            existingOrder.PaymentDetails = order.PaymentDetails;
            existingOrder.Status = order.Status;

            //DB.save changes


            return Ok("order patched");
        }
    }
}
