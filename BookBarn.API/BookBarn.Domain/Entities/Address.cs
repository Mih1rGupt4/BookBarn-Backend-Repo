using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Entities
{
    public class Address
    {
        public int AddressID {  get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

}
