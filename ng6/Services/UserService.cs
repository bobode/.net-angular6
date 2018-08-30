using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ng6.Models;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        
    }

    public class UserService : IUserService
    {
        private SCIContext db;
        UserManager<AspNetUsers> userManager;
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = "1", FirstName = "Test", LastName = "User", Username = "test", Password = "test" }

        };

        private readonly AppSettings _appSettings;

        public UserService(AppSettings appSettings, SCIContext dbcontext)
        {
            this._appSettings = appSettings;
            //this.db = dbcontext;
            //_appSettings = appSettings.Value;
            //this._users = db.AspNetUsers.Select(x => new User()
            //{
            //    FirstName = x.UserName,
            //    LastName = "",
            //    Username = x.UserName,
            //    Id = x.Id

            //}).ToList();
           
        }

        public User Authenticate(string username, string password)
        {

            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);            
            //var _user = db.AspNetUsers.FirstOrDefault(x => x.UserName == username);
            //var u = userManager.CreateAsync(_user, password);
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }
    }
}