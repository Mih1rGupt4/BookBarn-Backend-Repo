using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public virtual Book book { get; set; }
        public virtual User user { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public DateTime DateOfReview { get; set; }
        public string ReviewHeading { get; set; }
        public string ReviewImageUrl { get; set; }
    }
}
