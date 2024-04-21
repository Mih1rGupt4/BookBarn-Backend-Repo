﻿using BookBarn.Data.Repositories;
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
        //private readonly IWishlistRepository wishlistRepository=new WishlistRepository();

        private readonly IWishlistRepository wishlistRepository;

         public WishlistController(IWishlistRepository _wishlistRepository)
        {
            wishlistRepository = _wishlistRepository;
        }


        [HttpPost]
        [Route("api/wishlist/add/{userId}/{bookId}")]
        public IHttpActionResult AddToWishlist(int userId, int bookId)
        {
            try
            {
                
                if(wishlistRepository.AddToWishList(userId, bookId))
                {
                    return Ok("Book added to wishlist successfully.");
                }
                return Ok("Book is already in wishlist");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

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

        [HttpGet]
        [Route("api/wishlist/isExisting/{userId}/{bookId}")]
        public Boolean isExisting(int userId, int bookId)
        {
          
              return wishlistRepository.isExisting(userId, bookId);
                         
        }

    }
}
