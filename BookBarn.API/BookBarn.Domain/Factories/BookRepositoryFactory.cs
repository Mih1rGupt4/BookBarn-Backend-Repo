using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Factories
{
    public class BookRepositoryFactory
    {
        public static BookRepositoryFactory Instance { get; set; } = new BookRepositoryFactory();
        private BookRepositoryFactory() { }

        public IBooksRepository GetBookRepository()
        {
            string className = ConfigurationManager.AppSettings["BOOKREPOSITORY"];
            //reflection
            Type theType = Type.GetType(className);
            return (IBooksRepository)Activator.CreateInstance(theType);
        }
    }
}
