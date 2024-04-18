using BookBarn.Domain.Entities;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookBarn.API.Controllers
{
    public class OrderController : ApiController
    {

        List<Order> orderList = new List<Order>();

        // get
        // api/order/
        // get all orders (only for the admin) 
        public IHttpActionResult GetAllOrders()
        {
            var orders = orderList;
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
        public IHttpActionResult GetOrdersById(int id)
        {
            var order = new Order();
            if (order == null)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok(order); // if found then return 200 with data
        }


        // post
        // api/order
        // to post the order



        /*  empty json body structure for posting order data
         * 
        {
        "OrderID": 0,
        "UserID": null,
        "OrderItems": [
            {
                "OrderItemID": 0,
                "BookID": 0,
                "Quantity": 0,
                "Price": 0.0,
                "OrderID": 0,
                "Order": null
            }
        ],
        "TotalPrice": 0.0,
        "OrderDate": "0001-01-01T00:00:00",
        "ShippingAddress": {
            "AddressID": 0,
            "AddressLine1": null,
            "AddressLine2": null,
            "Street": null,
            "City": null,
            "State": null,
            "PostalCode": null,
            "Country": null
        },
        "PaymentDetails": {
            "PaymentDetailsID": 0,
            "Amount": 0.0,
            "TransactionId": null,
            "PaymentSource": null
        },
        "Status": 0
    }
        */



        // patch
        // api/order/{id}
        // edit the status for admin to change the status
        //[HttpPatch]
        public IHttpActionResult PatchEditStatus(int id, [FromBody] Delta<Order>order)
        {


            if (order == null)
            {
                return BadRequest("Missing data to patch");
            }

            var existingOrder = new Order();
            order.Patch(existingOrder);

            //DB.save changes


            return Ok();
        }
    }
}
