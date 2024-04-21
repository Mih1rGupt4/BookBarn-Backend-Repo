﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBarn.Domain;
using BookBarn.Domain.Dto.Book;
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
        public Book GetBookByID(int id)
        {
            return db.Books.Where(b => b.BookID == id).FirstOrDefault();
        }

        public List<Book> FilterBooks(BookFilterParams bookFilterParams)
        {
            var filteredBooks = db.Books.Where(b => (b.Author.Contains(bookFilterParams.Author) || bookFilterParams.Author == null) 
            && (b.Title.Contains(bookFilterParams.Title) || bookFilterParams.Title == null) 
            && (b.Category.Contains(bookFilterParams.Category) || bookFilterParams.Category == null)).ToList();
            return filteredBooks;
        }

        public Book AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return book;
        }

        public bool DeleteBook(int bookId)
        {
            Book book = db.Books.Find(bookId);
            if(book == null)
                return false;
            
            db.Books.Remove(book);
            db.SaveChanges();
            return true;
        }

        public Book EditBook(Book book)
        {
            db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return book;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            var booksByAuthor = db.Books.Where(b => b.Author.Contains(author) || author == null).ToList();
            return booksByAuthor;
        }

        public List<Book> GetBooksByCategory(string category)
        {
            var booksByCategory = db.Books.Where(b => b.Category.Contains(category) || category == null).ToList();
            return booksByCategory;
        }

        public List<Book> GetBooksByTitle(string title)
        {
            var booksByTitle = db.Books.Where(b => b.Title.Contains(title) || title == null).ToList();
            return booksByTitle;
        }
    }
}
