using BookBarn.Domain.Entities;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Data.Repositories
{
    public class ReviiewCumRatingRepo : IReviewCumRatingRepo
    {
        BookBarnDbContext db=new BookBarnDbContext();
        public List<ReviewCumRating> getAllReview()
        {
           
            return db.ReviewCumRatings.ToList();
        }
    }
}
