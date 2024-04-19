using BookBarn.Domain.Entities;
using System.Web.Http;
using System.Web.Routing;
using BookBarn.Domain.Interfaces;
using System.Web.Http.Cors;

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
    }
}
