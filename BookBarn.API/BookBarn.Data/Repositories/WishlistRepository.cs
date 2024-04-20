﻿using BookBarn.Domain.Entities;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Data.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly BookBarnDbContext dbContext = new BookBarnDbContext();

        /*public WishlistRepository(BookBarnDbContext _dbContext)
        {
            dbContext = _dbContext;
        }*/
        public void AddToWishlist(int userId, Book book)
        {
            try
            {
                // if the book already exists in the database
                var existingBook = dbContext.Books.FirstOrDefault(b => b.BookID == book.BookID);

                if (existingBook != null)
                {
                    // book exists, use the existing book entity
                    book = existingBook;
                }

                //  if the book is already in the user's wishlist
                if (!dbContext.WishLists.Any(w => w.UserId == userId && w.Book.BookID == book.BookID))
                {
                    // add the book to the user's wishlist
                    var wishlistItem = new WishList
                    {
                        UserId = userId,
                        Book = book
                    };

                    dbContext.WishLists.Add(wishlistItem);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddToWishList(int userId, int bookId)
        {
            WishList w = new WishList { UserId = userId, BookID = bookId };
            dbContext.WishLists.Add(w);
            dbContext.SaveChanges();

        }

        public List<WishList> GetWishlistItems(int userId)
        {
            try
            {
                // Retrieve wishlist items for the user
                List<WishList> wishlistItems = dbContext.WishLists.Where(w => w.UserId == userId).ToList();
                return wishlistItems;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void RemoveFromWishlist(int userId, int bookId)
        {
            try
            {
                // Find the wishlist item for the user and book
                var wishlistItem = dbContext.WishLists.FirstOrDefault(w => w.UserId == userId && w.Book.BookID == bookId);

                if (wishlistItem != null)
                {
                    // If found, remove the book from the user's wishlist
                    dbContext.WishLists.Remove(wishlistItem);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool isExisting(int userId, int bookId)
        {

            var wishlistItem = dbContext.WishLists.FirstOrDefault(w => w.UserId == userId && w.Book.BookID == bookId);
            if (wishlistItem != null)
            {
                return true;
            }
            return false;


        }


    }
}
