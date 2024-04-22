using BookBarn.Domain.Entities;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Data.Repositories
{
    public class RecommenderRepository : IRecommendation
    {
        BookBarnDbContext db;
        IBooksRepository Books;
        public RecommenderRepository()
        {
            db = new BookBarnDbContext();
            Books = new BooksRepository();
        }

        public double Get_Correlation(int[] Base_array, int[] Other_array)
        {
            if (Base_array.Length != Other_array.Length)
            {
                if (Base_array.Length > Other_array.Length)
                {
                    int l = Other_array.Length;
                    Array.Resize(ref Other_array, Base_array.Length);
                    for (int i = l; i < Base_array.Length; i++)
                    {
                        Base_array[i] += 1;
                        Other_array[i] = 1;
                    }
                }
            }

            int n = Base_array.Length;
            double sumXY = 0;
            double sumX = 0;
            double sumY = 0;
            double sumXSquare = 0;
            double sumYSquare = 0;

            for (int i = 0; i < n; i++)
            {
                if (Base_array[i] == 0 || Other_array[i] == 0)
                {
                    Base_array[i] += 1;
                    Other_array[i] += 1;
                }
                sumXY += Base_array[i] * Other_array[i];
                sumX += Base_array[i];
                sumY += Other_array[i];
                sumXSquare += Math.Pow(Base_array[i], 2);
                sumYSquare += Math.Pow(Other_array[i], 2);
            }
            double correlation = -1;
            correlation = (n * sumXY - sumX * sumY) /
                                         Math.Sqrt((n * sumXSquare - Math.Pow(sumX, 2)) * (n * sumYSquare - Math.Pow(sumY, 2)));
            if (double.IsNaN(correlation))
            {
                return -1;
            }
            return Math.Round(correlation, 4);

        }

        public List<Book> Get_recommended_book(List<int> bookIds)
        {
            // Retrieve books based on the provided bookIds
            var books = db.Books.Where(b => bookIds.Contains(b.BookID)).ToList();
            int maxCount = 15;
            // Extract distinct categories from the retrieved books
            var categories = books.Select(b => b.Category).Distinct().ToList();

            // Initialize list to store recommended books
            List<Book> recommendedBooks = new List<Book>();

            // Iterate over distinct categories
            foreach (var category in categories)
            {
                // Retrieve books for the current category and add them to recommendedBooks
                recommendedBooks.AddRange(db.Books.Where(b => b.Category == category && !bookIds.Contains(b.BookID)).Take(maxCount));
            }

            // Retrieve book ratings
            Dictionary<int, List<int>> data = GetBookRatings(books.Select(b => b.BookID).ToList());

            // Initialize list to store recommended books along with their correlation values
            var recommendedBooksCorrelation = new List<KeyValuePair<Book, double>>();

            // Iterate over recommended books
            foreach (var book in recommendedBooks)
            {
                // Get ratings for the current book
                var ratings = data.ContainsKey(book.BookID) ? data[book.BookID] : new List<int>();

                // Calculate correlation if ratings exist, otherwise assign -2
                double correlation = ratings.Count > 0 ?
                    Get_Correlation(ratings.ToArray(), bookIds.SelectMany(id => data.ContainsKey(id) ? data[id] : new List<int>()).ToArray())
                    : -2;

                // Add book and correlation to the list
                recommendedBooksCorrelation.Add(new KeyValuePair<Book, double>(book, correlation));
            }

            // Sort recommended books by correlation in descending order
            recommendedBooksCorrelation = recommendedBooksCorrelation.OrderByDescending(kv => kv.Value).ToList();

            // Take top recommended books based on correlation, up to the specified maximum count
            var topRecommendedBooks = recommendedBooksCorrelation.Take(maxCount).Select(kv => kv.Key).ToList();

            return topRecommendedBooks;
        }




        public Dictionary<int, List<int>> GetBookRatings(List<int> bookIds)
        {
            // Retrieve reviews for the provided bookIds
            var reviews = db.ReviewCumRatings
                .Where(r => bookIds.Contains(r.book.BookID))
                .ToList();

            // Group reviews by book ID and convert to dictionary
            var bookRatings = reviews
                .GroupBy(r => r.book.BookID)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(r => r.Rating).ToList()
                );

            return bookRatings;
        }

    }
}