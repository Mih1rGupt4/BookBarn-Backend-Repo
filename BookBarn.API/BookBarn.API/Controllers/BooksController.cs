using BookBarn.Data.Repositories;
using BookBarn.Domain.Dto.Book;
using BookBarn.Domain.Entities;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace BookBarn.API.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        // GET: Books
        public IHttpActionResult GetBooks()
        {
            IBooksRepository repo = new BooksRepository();
            var books = repo.GetAllBooks();
            if (books == null)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok(books); // if found then return 200 with data
        }

        [Route("{id}")]
        // GET: Books by ID
        public IHttpActionResult GetBooks(int id)
        {
            IBooksRepository repo = new BooksRepository();
            var book = repo.GetBookByID(id);
            if (book == null)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok(book); // if found then return 200 with data
        }

        [HttpPost]
        [Route("filter/all")]
        // GET: Books by Author
        public IHttpActionResult PostBooksByAllConditions([FromBody] BookFilterParams filterParams)
        {
            IBooksRepository repo = new BooksRepository();
            var book = repo.GetBooksByBias(filterParams.Title, filterParams.Author, filterParams.Category);
            if (book == null)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok(book); // if found then return 200 with data
        }

        [Route("filter/author/{author}")]
        // GET: Books by Author
        public IHttpActionResult GetBooksByAuthor(string author)
        {
            IBooksRepository repo = new BooksRepository();
            var book = repo.GetBooksByAuthor(author);
            if (book == null)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok(book); // if found then return 200 with data
        }

        [Route("filter/category/{category}")]
        // GET: Books by Author
        public IHttpActionResult GetBooksByCategory(string category)
        {
            IBooksRepository repo = new BooksRepository();
            var book = repo.GetBooksByCategory(category);
            if (book == null)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok(book); // if found then return 200 with data
        }

        [Route("filter/title/{title}")]
        // GET: Books by Author
        public IHttpActionResult GetBooksByTitle(string title)
        {
            IBooksRepository repo = new BooksRepository();
            var book = repo.GetBooksByTitle(title);
            if (book == null)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok(book); // if found then return 200 with data
        }


    }
}