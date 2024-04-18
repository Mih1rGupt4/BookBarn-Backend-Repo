﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBarn.Domain.Entities
{
    public class User
    {

            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }
            public Address Address { get; set; }
            public DateTime RegistrationDate {  get; set; } 
            public string Password { get; set; }
            public string Token { get; set; }
            public string Role { get; set; }
            public string Email { get; set; }
            public string RefreshToken { get; set; }
            public DateTime RefreshTokenExpiryTime { get; set; }
        
    }
}
