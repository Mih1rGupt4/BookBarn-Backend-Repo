using BookBarn.Domain.Dto.Book;
using BookBarn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Interfaces
{
    public interface IBooksRepository
    {
        Book AddBook(Book book);
        bool DeleteBook(int bookId);
        Book EditBook(Book book);
        List<Book> GetAllBooks();
        Book GetBookByID(int id);
        List<Book> GetBooksByCategory(string category);
        List<Book> GetBooksByTitle(string title);
        List<Book> GetBooksByAuthor(string author);
        List<Book> FilterBooks(BookFilterParams bookFilterParams);

    }
}
