using BookBarn.Data;
using BookBarn.Domain.Entities;
using System.Web.Http.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Routing;

namespace BookBarn.API.Controllers
{
    public class OrderController : ApiController
    {
        BookBarnDbContext db;

        public OrderController()
        {
            db = new BookBarnDbContext();
            //List<Order> orderList = new List<Order>();
        }



        // get
        // api/order/
        // get all orders (only for the admin) 
        public IHttpActionResult GetAllOrders()
        {
            var orders = db.Orders;
            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }


        // get
        // api/order/{id}
        // get all orders by user
        [Route("api/order/{id}")]
        public IHttpActionResult GetOrdersById(string id)
        {
            var userOrders = db.Orders.Where(o => o.UserID == id);
            if (userOrders == null)
            {
                return BadRequest();
            }
            return Ok(userOrders);
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
            db.Orders.Add(order);
            db.SaveChanges();
            return Created("location", order.OrderID);
        }

        // patch
        // api/order/{id}
        // edit the status for admin to change the status
        //[HttpPatch]
        // public IHttpActionResult PatchEditStatus(int id, [FromBody]Delta<Order>order)
        [HttpPatch]
        [Route("api/order/{id}")]
        public IHttpActionResult PatchEditStatus(int id, [FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Missing data to patch");
            }

            var existingOrder = db.Orders.FirstOrDefault(o => o.OrderID == id);


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
            db.SaveChanges();

            return Ok("order patched");
        }
    }
}
