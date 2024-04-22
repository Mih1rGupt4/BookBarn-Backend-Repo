using BookBarn.Data.Repositories;
using BookBarn.Domain.Interfaces;
using BookBarn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookBarn.API.Controllers
{
    [RoutePrefix("api/recommend")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RecommendationController : ApiController
    {
        private readonly IRecommendation repo;

        public RecommendationController(IRecommendation recommendation)
        {
            repo = recommendation;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetRecommendation([FromUri] List<int> bookIds) // Modify action to accept list of book IDs
        {
            var recommendedBooks = repo.Get_recommended_book(bookIds);
            return Ok(recommendedBooks);
        }
    }
}