using BookBarn.Domain.Entities;
using System.Web.Http;
using System.Web.Routing;
using BookBarn.Domain.Interfaces;
using System.Web.Http.Cors;
using System.Linq;
using System.Collections.Generic;

namespace BookBarn.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        //BookBarnDbContext db;
        IOrderRepository repo;

        public OrderController()
        {
            //repo = new OrderRepository();
            //db = new BookBarnDbContext();
            //List<Order> orderList = new List<Order>();
        }

        public OrderController(IOrderRepository repo)
        {
            this.repo = repo;
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
          
           repo.AddOrder(order);
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

            var existingOrder = repo.GetOrder(id);


            if (existingOrder == null)
            {

                return BadRequest("canot find the order with this id");

            }

            repo.UpdateOrderStatus(existingOrder, order);

            return Ok("order patched");
        }







        // ---------------------------------------
        // new API's
        // ---------------------------------------



        [HttpGet]
        [Route("api/order/all")]
        public IHttpActionResult GetAll()
        {
            var orders = repo.GetAll();
            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        // Action method for handling requests with an id parameter
        [HttpGet]
        [Route("api/order/all/{id}")]
        public IHttpActionResult GetAllByUserId(string id)
        {

            var userlist = repo.GetAllByUserId(id);
            if (userlist == null)
            {
                return NotFound();
            }
            return Ok(userlist);
        }


        // Action method for handling requests without an id parameter
        [HttpGet]
        [Route("api/order/active")]
        public IHttpActionResult GetAllActive()
        {

            var activelist = repo.GetAllActive();

            if (activelist == null)
            {
                return NotFound();
            }

            return Ok(activelist);
        }

        // Action method for handling requests with an id parameter
        [HttpGet]
        [Route("api/order/active/{id}")]
        public IHttpActionResult GetActiveOrdersByUserId(string id)
        {

            var userActivelist = repo.GetActiveOrdersByUserId(id);
            if (userActivelist == null)
            {
                return NotFound();
            }

            return Ok(userActivelist);
        }


        // Action method for handling requests without an id parameter
        [HttpGet]
        [Route("api/order/completed")]
        public IHttpActionResult GetAllCompleted()
        {

            var completedlist = repo.GetAllCompleted();
            if (completedlist == null)
            {
                return NotFound();
            }

            return Ok(completedlist);
        }

        // Action method for handling requests with an id parameter
        [HttpGet]
        [Route("api/order/completed/{id}")]
        public IHttpActionResult GetCompletedOrdersByUserId(string id)
        {

            var usercompletedlist = repo.GetCompletedOrdersByUserId(id);


            if (usercompletedlist == null)
            {
                return NotFound();
            }

            return Ok(usercompletedlist);
        }



        // Action method for handling requests without an id parameter
        [HttpGet]
        [Route("api/order/cancelled")]
        public IHttpActionResult GetAllCancelled()
        {

            var cancelledlist = repo.GetAllCancelled();

            if (cancelledlist == null)
            {
                return NotFound();
            }

            return Ok(cancelledlist);
        }

        // Action method for handling requests with an id parameter
        [HttpGet]
        [Route("api/order/cancelled/{id}")]
        public IHttpActionResult GetCancelledOrdersByUserId(string id)
        {

            var usercancelledlist = repo.GetCancelledOrdersByUserId(id);

            if (usercancelledlist == null)
            {
                return NotFound();
            }

            return Ok(usercancelledlist);
        }

    }
}