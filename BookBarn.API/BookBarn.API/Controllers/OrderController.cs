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
        private List<Order> orders = new List<Order>();
        //BookBarnDbContext db = new BookBarnDbContext();

        public OrderController()
        {
            //BookBarnDbContext db = new BookBarnDbContext();
            //List<Order> orderList = new List<Order>();


        }



        // get
        // api/order/
        // get all orders (only for the admin) 
        public IHttpActionResult GetAllOrders()
        {
            var orders = new List<Order>();
            //List<Order> orders = db.Orders.ToList();
            if (orders == null)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok(orders); // if found then return 200 with data
        }


        // get
        // api/order/{id}
        // get all orders by user
        [Route("api/order/{id}")]
        public IHttpActionResult GetOrdersById(string id)
        {
            var alluserorders = new Order(); //orders.Where(o => o.UserID == id).ToList();
            if (alluserorders == null)// || alluserorders.Count() == 0)
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
            return Created("location", orders.Count()); // if found then return 200 with data
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
