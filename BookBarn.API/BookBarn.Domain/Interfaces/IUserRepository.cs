using BookBarn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string username);
        
        void AddUser(User user);    
        

    }
}
