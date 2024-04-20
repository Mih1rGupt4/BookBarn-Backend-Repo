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
        private readonly IBooksRepository _repo = null;

        public BooksController(IBooksRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetBooks()
        {
            var books = _repo.GetAllBooks();
            var bookCardDtoList = ConvertBookToBookCarDto(books);
            return OkOrNotFound(books);
        }

        public List<BookCardDto> ConvertBookToBookCarDto(List<Book> books)
        {
            List<BookCardDto> bookCardDtos = new List<BookCardDto>();

            foreach(Book book in books)
            {
                bookCardDtos.Add(new BookCardDto
                {
                    Author = book.Author,
                    BookID = book.BookID,
                    Category = book.Category,
                    ImageUrlMedium = book.ImageUrlMedium,
                    Price = book.Price,
                    Stock = book.Stock,
                    Title = book.Title
                });
            }

            return bookCardDtos;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBookById(int id)
        {
            var book = _repo.GetBookByID(id);
            return OkOrNotFound(book);
        }

        // GET: Books by Author, Title or Category
        [HttpPost]
        [Route("filter")]
        public IHttpActionResult FilterBooks([FromBody] BookFilterParams filterParams)
        {
            var books = _repo.FilterBooks(filterParams);
            return OkOrNotFound(books);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteBook(int id)
        {
            bool success = _repo.DeleteBook(id);
            if (!success)
                return NotFound();

            return Ok($"Book with ID {id} successfully deleted");
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddBook([FromBody] Book book)
        {
            var newBook = _repo.AddBook(book);
            return OkOrNotFound(newBook);
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult EditBook([FromBody] Book book)
        {
            var updatedBook = _repo.EditBook(book);
            return OkOrNotFound(updatedBook);
        }

        private IHttpActionResult OkOrNotFound(object data)
        {
            if (data == null)
                return NotFound();

            return Ok(data);
        }




        // GET: Books by Author

        [Route("filter/author/{author}")]
        public IHttpActionResult GetBooksByAuthor(string author)
        {
            var book = _repo.GetBooksByAuthor(author);
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
            var book = _repo.GetBooksByCategory(category);
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
            var book = _repo.GetBooksByTitle(title);
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