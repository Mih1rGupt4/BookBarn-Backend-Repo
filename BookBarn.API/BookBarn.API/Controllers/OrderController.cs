﻿using BookBarn.Domain.Entities;
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
        // get
        // api/order/
        // get all orders (only for the admin) 
        public IHttpActionResult GetProductById()
        {
            var orders = new List<Order>();
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
        public IHttpActionResult GetProductById(int id)
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



        // patch
        // api/order/{id}
        // edit the status for admin to change the status
        [HttpPatch]
        public IHttpActionResult PatchEditStatus(int id)
        {
            return Ok();
        }
    }
}
