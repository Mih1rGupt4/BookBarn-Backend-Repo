﻿using BookBarn.API.Models;
using BookBarn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookBarn.Data;

namespace BookBarn.API.Controllers
{
    public class ReviewCumRatingsController : ApiController
    {
        private BookBarnDbContext db = new BookBarnDbContext();

        // GET: api/ReviewCumRatings

        // sample url format ...
        // https://localhost:44348/api/ReviewCumRatings?type=positive
        public IQueryable<ReviewCumRating> GetReviewCumRatings(string type)
        {
            if (type == "positive")
            {
                return db.ReviewCumRatings.Where(rr=>rr.Rating>3);
            }
            else if(type == "negative")
            {
                return db.ReviewCumRatings.Where(rr => rr.Rating <3 );
            }
            else if(type =="neutral")
            {
                return db.ReviewCumRatings.Where(rr => rr.Rating == 3);
            }
            else if(type == "one")
            {
                return db.ReviewCumRatings.Where(rr => rr.Rating == 1);
            }
            else if(type == "two")
            {
                return db.ReviewCumRatings.Where(rr => rr.Rating == 2);
            }
            else if(type == "three")
            {
                return db.ReviewCumRatings.Where(rr => rr.Rating == 3);
            }
            else if (type == "four")
            {
                return db.ReviewCumRatings.Where(rr => rr.Rating == 4);
            }
            else
            {
                return db.ReviewCumRatings.Where(rr => rr.Rating == 5);
            }
        
        
            /*return db.ReviewCumRatings;*/
        }

        // GET: api/ReviewCumRatings/5
        [ResponseType(typeof(ReviewCumRating))]
        public IHttpActionResult GetReviewCumRating(int id)
        {
            ReviewCumRating reviewCumRating = db.ReviewCumRatings.Find(id);
            if (reviewCumRating == null)
            {
                return NotFound();
            }

            return Ok(reviewCumRating);
        }

        // PUT: api/ReviewCumRatings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReviewCumRating(int id, ReviewCumRating reviewCumRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reviewCumRating.ReviewCumRatingId)
            {
                return BadRequest();
            }

            db.Entry(reviewCumRating).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewCumRatingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ReviewCumRatings
        [ResponseType(typeof(ReviewCumRating))]
        public IHttpActionResult PostReviewCumRating(ReviewCumRating reviewCumRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReviewCumRatings.Add(reviewCumRating);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reviewCumRating.ReviewCumRatingId }, reviewCumRating);
        }

        // DELETE: api/ReviewCumRatings/5
        [ResponseType(typeof(ReviewCumRating))]
        public IHttpActionResult DeleteReviewCumRating(int id)
        {
            ReviewCumRating reviewCumRating = db.ReviewCumRatings.Find(id);
            if (reviewCumRating == null)
            {
                return NotFound();
            }

            db.ReviewCumRatings.Remove(reviewCumRating);
            db.SaveChanges();

            return Ok(reviewCumRating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReviewCumRatingExists(int id)
        {
            return db.ReviewCumRatings.Count(e => e.ReviewCumRatingId == id) > 0;
        }
    }
}
