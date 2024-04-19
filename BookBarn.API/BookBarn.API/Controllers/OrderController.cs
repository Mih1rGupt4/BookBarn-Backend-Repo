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



        // get
        // api/order/
        // get all orders (only for the admin) 
        public IHttpActionResult GetAllOrders()
        {
            var orders = repo.GetAllOrders();
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
            var userOrders = repo.GetAllOrdersForUser(id);
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



        [HttpGet]
        [Route("api/order/all")]
        public IHttpActionResult GetAll()
        {
            var orders = repo.GetAllOrders();
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
            var orders = repo.GetAllOrders();
            if (orders == null)
            {
                return NotFound();
            }

            var userlist = orders.Where(o => o.UserID == id);
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
            var orders = repo.GetAllOrders();
            if (orders == null)
            {
                return NotFound();
            }

            var activelist = orders.Where(o => o.Status == OrderStatus.Ordered || o.Status == OrderStatus.Packed
                || o.Status == OrderStatus.Dispatched || o.Status == OrderStatus.OnTheWay);
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
            var orders = repo.GetAllOrders();
            if (orders == null)
            {
                return NotFound();
            }

            var userActivelist = orders.Where(o => o.UserID == id &&
                (o.Status == OrderStatus.Ordered || o.Status == OrderStatus.Packed
                || o.Status == OrderStatus.Dispatched || o.Status == OrderStatus.OnTheWay)
            );
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
            var orders = repo.GetAllOrders();
            if (orders == null)
            {
                return NotFound();
            }

            var completedlist = orders.Where(o => o.Status == OrderStatus.Delivered);
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
            var orders = repo.GetAllOrders();
            if (orders == null)
            {
                return NotFound();
            }

            var usercompletedlist = orders.Where(o => o.UserID == id && o.Status == OrderStatus.Delivered);
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
            var orders = repo.GetAllOrders();
            if (orders == null)
            {
                return NotFound();
            }

            var cancelledlist = orders.Where(o => o.Status == OrderStatus.Cancelled);
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
            var orders = repo.GetAllOrders();
            if (orders == null)
            {
                return NotFound();
            }

            var usercancelledlist = orders.Where(o => o.UserID == id && o.Status == OrderStatus.Cancelled);
            if (usercancelledlist == null)
            {
                return NotFound();
            }

            return Ok(usercancelledlist);
        }

    }
}
