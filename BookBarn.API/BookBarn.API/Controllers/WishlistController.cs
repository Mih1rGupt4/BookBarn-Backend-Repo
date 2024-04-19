using BookBarn.Data;
using BookBarn.Domain.Entities;
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
        BookBarnDbContext db = new BookBarnDbContext();

        // get
        // api/wishlist/
        // get all wishlist (only for the admin) 
        public IHttpActionResult GetAllWishLists()
        {
            return Ok(db.Wishlists); // if found then return 200 with data
        }


        // get
        // api/wishlist/{userId}
        // get all wishlists by user
        [Route("{userId}")]
        public IHttpActionResult GetWishlistByUserId(int userId)
        {
            var alluserwishlist = db.Wishlists.Where(w => w.UserId == userId).ToList();
            if (alluserwishlist == null || alluserwishlist.Count() == 0)
            {
                return BadRequest();
            }
            return Ok(alluserwishlist); // if found then return 200 with data
        }


        // post
        [HttpPost]
        public IHttpActionResult PostAddWishlist(int bookId,int userId)
        {
           
            Wishlist w = new Wishlist { UserId = userId, BookID = bookId };
            db.Wishlists.Add(w);
            db.SaveChanges();
            return Created("location", db.Wishlists.Count()); // if found then return 200 with data

        }


        [HttpPost]
        public IHttpActionResult PostWishlist(Wishlist wishlist)
        {

            db.Wishlists.Add(wishlist);
            db.SaveChanges();
            return Created("location", db.Wishlists.Count()); // if found then return 200 with data

        }







        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            // is resource found
            var WishListToDelete = db.Wishlists.Find(id);
            if (WishListToDelete == null)
            {
                return NotFound();
            }
            db.Wishlists.Remove(WishListToDelete);
            db.SaveChanges();
            return Ok();

        }
    }
}
