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
            //user.RegistrationDate = DateTime.Now.Date;
            user.Role = "User";
            db.Users.Add(user);
            db.SaveChanges();
        }

        public User GetUser(string username)
        {
           
            return db.Users.Where(p=>p.Username == username).FirstOrDefault();
        }

        
    }
}
