using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Interfaces
{
    public interface IWishlist
    {
        
        public List<Wishlist> GetWishlistItems(int userId);
        void AddToWishlist(int userId, [FromBody] Book book)
        void RemoveFromWishlist(int userId, int bookId);

    }
}
