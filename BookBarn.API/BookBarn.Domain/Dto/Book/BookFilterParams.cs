using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Dto.Book
{
    public class BookFilterParams
    {
        public string Author { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
    }

}
