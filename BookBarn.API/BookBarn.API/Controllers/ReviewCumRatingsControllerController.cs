using BookBarn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookBarn.API.Models;
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

using BookBarn.Domain.Interfaces;
using BookBarn.Data.Repositories;
namespace BookBarn.API.Controllers
{
    public class ReviewCumRatingsControllerController : ApiController
    {


        public IReviewCumRatingRepo repo = new ReviewCumRatingRepo();

        //constructor for DI using Unity IOC
        /* public ReviewCumRatingsController(IReviewCumRatingRepo repo)
         {
         this.repo = repo;
         }*/

        public ReviewCumRatingsControllerController()
        {

        }

        //    // GET: api/ReviewCumRatings
        //    // sample url format ...
        //    // https://localhost:44348/api/ReviewCumRatings
        public IQueryable<ReviewCumRating> GetAllReviewCumRatings()
        {
            return repo.GetAllReviewCumRatings() as IQueryable<ReviewCumRating>;
        }


        //  THIS IS THE MAIN END POINT THAT WILL BE MOSTLY CALLED 
        // https://localhost:44348/api/ReviewCumRatings/forbook/1
        [HttpGet]

        [Route("api/ReviewCumRatings/forbook/{bookId}")]
        public IQueryable<ReviewCumRating> GetAllReviewsOfBook(int bookId)
        {
            return repo.GetAllReviewsOfBook(bookId) as IQueryable<ReviewCumRating>;
        }

        //    // GET: api/ReviewCumRatings
        //    // sample url format ...
        //    // https://localhost:44348/api/ReviewCumRatings?type=positive
        public IQueryable<ReviewCumRating> GetReviewCumRatings(string type)
        {
            return repo.GetReviewCumRatings(type) as IQueryable<ReviewCumRating>;
        }

        // GET: api/ReviewCumRatings/5
        [ResponseType(typeof(ReviewCumRating))]
        public IHttpActionResult GetReviewCumRating(int id)
        {
            ReviewCumRating reviewCumRating = repo.GetReviewCumRating(id); //db.ReviewCumRatings.Find(id);
            if (reviewCumRating == null)
            {
                return NotFound();
            }

            return Ok(reviewCumRating);
        }


        [ResponseType(typeof(ReviewCumRating))]

        [HttpGet]

        [Route("api/ReviewCumRatings/{bookId}/userName")]
        public IHttpActionResult GetReviewCumRatingBasedOnUserNameandBookId(int bookId, string userName)
        {
            ReviewCumRating reviewCumRating = repo.GetReviewCumRatingBasedOnUser(bookId, userName); //db.ReviewCumRatings.Find(id);
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

            //db.Entry(reviewCumRating).State = EntityState.Modified;
            if (repo.PutReviewCumRating(id, reviewCumRating))
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return BadRequest();
            }

        }

        //POST: api/ReviewCumRatings
        [ResponseType(typeof(ReviewCumRating))]
        public IHttpActionResult PostReviewCumRating(ReviewCumRating reviewCumRating)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (repo.PostReviewCumRating(reviewCumRating))
            {
                return CreatedAtRoute("DefaultApi", new { id = reviewCumRating.ReviewCumRatingId }, reviewCumRating);
            }

            return BadRequest();
        }

        // DELETE: api/ReviewCumRatings/5
        [ResponseType(typeof(ReviewCumRating))]
        public IHttpActionResult DeleteReviewCumRating(int id)
        {
            if (repo.DeleteReviewCumRating(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
