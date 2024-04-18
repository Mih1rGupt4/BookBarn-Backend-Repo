using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBarn.Domain;
using BookBarn.Domain.Entities;
using BookBarn.Domain.Interfaces;

namespace BookBarn.Data.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        BookBarnDbContext db = new BookBarnDbContext();
        public List<Book> GetAllBooks()
        {
            var allBooks = db.Books.ToList();
            return allBooks;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            var booksByAuthor = db.Books.Where(b => b.Author.Contains(author)).ToList();
            return booksByAuthor;
        }

        public List<Book> GetBooksByCategory(string category)
        {
            var booksByCategory = db.Books.Where(b => b.Category.Contains(category)).ToList();
            return booksByCategory;
        }

        public List<Book> GetBooksByTitle(string title)
        {
            var booksByTitle = db.Books.Where(b => b.Title.Contains(title)).ToList();
            return booksByTitle;
        }
    }
}
