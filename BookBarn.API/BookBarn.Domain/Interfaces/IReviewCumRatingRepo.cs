using BookBarn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Interfaces
{
    public interface IReviewCumRatingRepo
    {
        IQueryable<ReviewCumRating> GetAllReviewCumRatings();

        IQueryable<ReviewCumRating> GetReviewCumRatings(string type);
        
        ReviewCumRating GetReviewCumRating(int id);
        
         bool PutReviewCumRating(int id, ReviewCumRating reviewCumRating);
        
        bool PostReviewCumRating(ReviewCumRating reviewCumRating);
       
        bool DeleteReviewCumRating(int id);

    }
}
