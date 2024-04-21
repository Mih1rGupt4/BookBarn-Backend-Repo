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
            var books = db.Books.Where(b => bookIds.Contains(b.BookID)).ToList();
            var categories = books.Select(b => b.Category).Distinct().ToList();

            List<Book> res = new List<Book>();
            foreach (var category in categories)
            {
                res.AddRange(Books.GetBooksByCategory(category));
            }

            res = res.Distinct().ToList();

            Dictionary<int, List<int>> data = GetBookRatings(books.Select(b => b.BookID).ToList());
            var recommendedBooks = new List<KeyValuePair<Book, double>>();
            foreach (var b in res)
            {
                if (!bookIds.Contains(b.BookID))
                {
                    var ratings = data.ContainsKey(b.BookID) ? data[b.BookID] : new List<int>();
                    double correlation = Get_Correlation(ratings.ToArray(), bookIds.SelectMany(id => data.ContainsKey(id) ? data[id] : new List<int>()).ToArray());
                    recommendedBooks.Add(new KeyValuePair<Book, double>(b, correlation));
                }
            }

            recommendedBooks = recommendedBooks.OrderByDescending(kv => kv.Value).ToList();

            return recommendedBooks.Take(15).Select(kv => kv.Key).ToList();
        }



        public Dictionary<int, List<int>> GetBookRatings(List<int> bookIds)
        {
            var bookRatings = db.ReviewCumRatings
                .Where(r => bookIds.Contains(r.book.BookID))
                .GroupBy(r => r.book.BookID)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(r => r.Rating).ToList()
                );

            return bookRatings;
        }

    }
}