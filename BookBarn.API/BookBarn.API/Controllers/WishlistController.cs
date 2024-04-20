using BookBarn.Data.Repositories;
using BookBarn.Domain.Entities;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookBarn.API.Controllers
{
    public class WishlistController : ApiController
    {
        private readonly IWishlistRepository wishlistRepository=new WishlistRepository();
        
       /* public WishlistController(IWishlistRepository _wishlistRepository)
        {
            wishlistRepository = _wishlistRepository;
        }*/
        [HttpPost]
        [Route("api/wishlist/add")]
        public IHttpActionResult AddToWishlist(int userId, [FromBody] Book book)
        {
            try
            {
                wishlistRepository.AddToWishlist(userId, book);
                return Ok("Book added to wishlist successfully.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        [Route("api/wishlist/remove")]
        public IHttpActionResult RemoveFromWishlist(int userId, int bookId)
        {
            try
            {
                wishlistRepository.RemoveFromWishlist(userId, bookId);
                return Ok("Book removed from wishlist successfully.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("api/wishlist/{userId}")]
        public IHttpActionResult GetWishlistItems(int userId)
        {
            try
            {
                List<WishList> wishlistItems = wishlistRepository.GetWishlistItems(userId);
                return Ok(wishlistItems);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }
}
