using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Entities
{
    public class ReviewCumRating
    {
        public int ReviewCumRatingId { get; set; }
        public Book book { get; set; }
        public User user { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
