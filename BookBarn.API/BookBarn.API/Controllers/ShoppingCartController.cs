using BookBarn.Data.Repositories;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookBarn.API.Controllers
{
    public class ShoppingCartController : ApiController
    {

        //Add to cart
        //Remove from cart
        //Update quantity of the cart
        //View Cart

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
    }
}
