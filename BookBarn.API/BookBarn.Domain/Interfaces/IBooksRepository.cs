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
        List<Book> GetAllBooks();
        List<Book> GetBooksByCategory(string category);
        List<Book> GetBooksByTitle(string title);
        List<Book> GetBooksByAuthor(string author);

    }
}
