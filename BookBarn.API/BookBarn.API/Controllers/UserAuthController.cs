using BookBarn.Data.Repositories;
using BookBarn.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.Http;
using BookBarn.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNet.Identity;
using BookBarn.API.Helpers;
using System.Web.Http.Cors;

namespace BookBarn.API.Controllers
{
    [RoutePrefix("api/auth")]
    [EnableCors(origins: "http://localhost:4200", headers: "", methods: "*")]
    public class UserAuthController : ApiController
    {
        IUserRepository repo = new UserRepository();

        [HttpPost]
        [Route("login")]

        public IHttpActionResult Login([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            User user = repo.GetUser(userObj.Username);


            if (user == null)
            {
                return NotFound();
            }

            if (!Helpers.PasswordHasher.VerifyPassword(userObj.Password, user.Password))
                BadRequest("Password Incorrect");

            user.Token = CreateJWT(user);


            return Ok($"{user.Token}");



        }

        [HttpPost]
        [Route("register")]

        public IHttpActionResult SignUp([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest("No object recieved from body");
            }

            if (repo.GetUser(userObj.Username) != null)
            {
                return BadRequest("Account already exists. Please login");
            }

            var pass = CheckPasswordStrength(userObj.Password);
            if (!string.IsNullOrEmpty(pass))
            {
                return BadRequest(pass);
            }

            userObj.Password = Helpers.PasswordHasher.HashPassword(userObj.Password);


            repo.AddUser(userObj);

            return Created($"api/user/{userObj.Id}", userObj);
        }

        [Authorize]
        [HttpGet]
        [Route("userdetails/{username}")]
        public IHttpActionResult GetUserDetails(string username)
        {
            var user = repo.GetUser(username);
            if (user == null) return BadRequest("User not found");

            return Ok(user);
        }




        private string CreateJWT(User user)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes("veryverylongandsecuresecretkeythatshouldbeusedforjwtgeneration");
            ClaimsIdentity identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.Name,user.Username)
            });
            SigningCredentials credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials,

            };

            SecurityToken token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);


        }

        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 8)
                sb.Append("Passwrod length must be more than 8" + Environment.NewLine);
            if (!Regex.IsMatch(password, "[a-z]"))
                sb.Append("Password must contain lowercase letters" + Environment.NewLine);
            if (!Regex.IsMatch(password, "[A-Z]"))
                sb.Append("Password must contain uppercase letters" + Environment.NewLine);
            if (!Regex.IsMatch(password, "[0-9]"))
                sb.Append("Password must contain numbers" + Environment.NewLine);
            if (!Regex.IsMatch(password, "[!,@,#,$,%,^,&,*,-,=]"))
                sb.Append("Password must contain {!,@,#,$,%,^,&,*,-,=}" + Environment.NewLine);

            return sb.ToString();
        }


    }
}
