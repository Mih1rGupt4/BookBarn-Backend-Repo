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

        public RecommendationController()
        {
            repo = new RecommenderRepository();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetRecommendation([FromUri] List<int> bookIds) // Modify action to accept list of book IDs
        {
            var recommendedBooks = repo.Get_recommended_book(bookIds);
            /*List<Book> books = new List<Book>
{
    new Book
    {
        BookID = 1,
        ISBN = "9780345806972",
        Title = "1984",
        Category = "Fiction",
        Author = "George Orwell",
        Publisher = "Signet Classics",
        Price = 9.99,
        Stock = 10,
        YearOfPublication = "1949",
        ImageUrlSmall = "https://example.com/1984_small.jpg",
        ImageUrlMedium = "https://example.com/1984_medium.jpg",
        ImageUrlLarge = "https://example.com/1984_large.jpg"
    },
    new Book
    {
        BookID = 2,
        ISBN = "9780061120084",
        Title = "To Kill a Mockingbird",
        Category = "Fiction",
        Author = "Harper Lee",
        Publisher = "Harper Perennial Modern Classics",
        Price = 8.99,
        Stock = 15,
        YearOfPublication = "1960",
        ImageUrlSmall = "https://example.com/to_kill_a_mockingbird_small.jpg",
        ImageUrlMedium = "https://example.com/to_kill_a_mockingbird_medium.jpg",
        ImageUrlLarge = "https://example.com/to_kill_a_mockingbird_large.jpg"
    },
    new Book
    {
        BookID = 3,
        ISBN = "9780141187761",
        Title = "Animal Farm",
        Category = "Fiction",
        Author = "George Orwell",
        Publisher = "Penguin Classics",
        Price = 7.99,
        Stock = 20,
        YearOfPublication = "1945",
        ImageUrlSmall = "https://example.com/animal_farm_small.jpg",
        ImageUrlMedium = "https://example.com/animal_farm_medium.jpg",
        ImageUrlLarge = "https://example.com/animal_farm_large.jpg"
    },
    // Add more books as needed
};
            return Ok(books);*/
            return Ok(recommendedBooks);
        }
    }
}