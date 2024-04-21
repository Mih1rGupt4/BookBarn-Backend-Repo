using BookBarn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Interfaces
{
    public interface IWishlistRepository
    {
        void AddToWishlist(int userId, Book book);
        void RemoveFromWishlist(int userId, int bookId);
        List<WishList> GetWishlistItems(int userId);
        bool AddToWishList(int userId, int bookId);
        bool isExisting(int userId, int bookId);
    }
}
