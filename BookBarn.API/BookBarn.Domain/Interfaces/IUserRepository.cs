﻿using BookBarn.Domain.Entities;
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
        List<User> GetAllUsers();
        void DeleteUser(User user);

        User GetUser(int id);
        void UpdateUser(User user);

    }
}