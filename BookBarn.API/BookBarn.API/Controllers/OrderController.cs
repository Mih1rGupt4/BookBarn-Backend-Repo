using BookBarn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace BookBarn.API.Controllers
{
    public class OrderController : ApiController
    {



        // get
        // api/order/
        // get all orders (only for the admin) 


        // get
        // api/order/{id}
        // get all orders by user


        // post
        // api/order
        // to post the order



        // patch
        // api/order/{id}
        // edit the status for admin to change the status
        [HttpPatch]
        public IHttpActionResult PatchEditStatus(int id, [FromBody] Delta<Order>order)
        {


            if(order == null)
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
