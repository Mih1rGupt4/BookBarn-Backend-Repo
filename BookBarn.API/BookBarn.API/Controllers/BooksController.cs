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
        IBooksRepository repo = null;

        public BooksController(IBooksRepository repo)
        {
            this.repo = repo;
        }

        // GET: Books
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetBooks()
        {
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
        [Route("filter")]
        // GET: Books by Author, Title or Category
        public IHttpActionResult GetBooksByAllConditions([FromBody] BookFilterParams filterParams)
        {
            var book = repo.GetBooksByBias(filterParams.Title, filterParams.Author, filterParams.Category);
            if (book == null)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok(book); // if found then return 200 with data
        }

        [Route("{id}")]
        // Delete: Book by ID
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            bool success = repo.DeleteBook(id);
            if (!success)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok($"Book with ID {id} successfully deleted"); // if found then return 200 with data
        }

        [HttpPost]
        [Route("")]
        // POST: Insert Books
        public IHttpActionResult AddBooks([FromBody] Book book)
        {
            var newbook = repo.AddBook(book);
            if (newbook == null)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok(newbook); // if found then return 200 with data
        }

        [HttpPut]
        [Route("")]
        // POST: Edit Books
        public IHttpActionResult EditBooks([FromBody] Book book)
        {
            var newbook = repo.EditBook(book);
            if (newbook == null)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok(newbook); // if found then return 200 with data
        }

        [Route("filter/author/{author}")]
        // GET: Books by Author
        public IHttpActionResult GetBooksByAuthor(string author)
        {
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