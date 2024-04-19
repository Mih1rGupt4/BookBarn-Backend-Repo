using BookBarn.Domain.Entities;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        BookBarnDbContext db= new BookBarnDbContext();

        public void AddUser(User user)
        {
            db.Users.Add(user);
        }

        public User GetUser(string username)
        {
           
            return db.Users.Find(username);
        }

        
    }
}
