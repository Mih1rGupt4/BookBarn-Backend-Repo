using BookBarn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Interfaces
{
    public interface IRecommendation
    {
        double Get_Correlation(int[] base_array, int[] other_array);

        List<Book> Get_recommended_book(List<int> book_id);

        Dictionary<int, List<int>> GetBookRatings(List<int> bookIds);

    }
}
