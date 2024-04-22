using BookBarn.Data.Repositories;
using BookBarn.Domain.Entities;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookBarn.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShoppingCartController : ApiController
    {

        //Add to cart
        //Remove from cart
        //Update quantity of the cart
        //View Cart
        public IHttpActionResult Options()
        {
            return Ok();
        }
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartController() { }
        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }


        [HttpGet]
        public IHttpActionResult GetCart(int id)
        {
            var result = _shoppingCartRepository.GetShoppingCartById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPatch]
        public IHttpActionResult UpdateCartItem(int id, int quantity)
        {
            var result = _shoppingCartRepository.UpdateCartItemQuantity(id, quantity);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }


        [HttpPost]
       // [Route("api/ShoppingCart/{id}")]
        public IHttpActionResult AddToCart([FromBody] CartItem item) {
            var id = item.ShoppingCartID;
            var result = _shoppingCartRepository.AddCartItem(id,item);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        [HttpDelete]
        public IHttpActionResult RemoveFromCart(int cartId, int itemId)
        {

            var result = _shoppingCartRepository.RemoveCartItem(cartId,itemId);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        [Route("api/ShoppingCart/clear-cart/{id}")]
        [HttpDelete]
        public IHttpActionResult ClearCart(int id)
        {
            _shoppingCartRepository.Clear(id); // Clear the shopping cart items
            return Ok("Shopping cart cleared successfully");
        }

    }
}
