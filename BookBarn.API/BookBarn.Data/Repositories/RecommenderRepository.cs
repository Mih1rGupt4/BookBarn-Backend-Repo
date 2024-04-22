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

            // Extract distinct categories from the retrieved books
            var categories = books.Select(b => b.Category).Distinct().ToList();

            // Initialize list to store recommended books
            List<Book> recommendedBooks = new List<Book>();

            // Iterate over distinct categories
            foreach (var category in categories)
            {
                // Retrieve books for the current category and add them to recommendedBooks
                recommendedBooks.AddRange(Books.GetBooksByCategory(category));
            }

            // Remove duplicates from the recommendedBooks list
            recommendedBooks = recommendedBooks.Distinct().ToList();

            // Retrieve book ratings
            Dictionary<int, List<int>> data = GetBookRatings(books.Select(b => b.BookID).ToList());

            // Initialize list to store recommended books along with their correlation values
            var recommendedBooksCorrelation = new List<KeyValuePair<Book, double>>();

            // Iterate over recommended books
            foreach (var book in recommendedBooks)
            {
                // Check if the book is not in the provided bookIds list
                if (!bookIds.Contains(book.BookID))
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
            }

            // Sort recommended books by correlation in descending order
            recommendedBooksCorrelation = recommendedBooksCorrelation.OrderByDescending(kv => kv.Value).ToList();

            // Ensure that the list contains at least 15 books
            while (recommendedBooksCorrelation.Count < 15)
            {
                // Check if categories list is not empty before accessing a random category
                if (categories.Any())
                {
                    // Add random book from the same category
                    var randomCategory = categories[new Random().Next(categories.Count)];
                    var randomBook = Books.GetBooksByCategory(randomCategory).OrderBy(b => Guid.NewGuid()).FirstOrDefault();
                    if (randomBook != null)
                    {
                        // Assign correlation as 0 for randomly added books
                        recommendedBooksCorrelation.Add(new KeyValuePair<Book, double>(randomBook, 0));
                    }
                    else
                    {
                        break; // Break the loop if no more books are available
                    }
                }
                else
                {
                    break; // Break the loop if categories list is empty
                }
        }

            // Take top 15 recommended books based on correlation
            var topRecommendedBooks = recommendedBooksCorrelation.Take(15).Select(kv => kv.Key).ToList();

            return topRecommendedBooks;
        }

        public Dictionary<int, List<int>> GetBookRatings(List<int> bookIds)
        {
            // Retrieve reviews for the provided bookIds
            var reviews = db.Reviews
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