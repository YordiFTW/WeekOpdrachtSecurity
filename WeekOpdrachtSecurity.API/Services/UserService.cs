using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WeekOpdrachtSecurity.API.Entities;
using WeekOpdrachtSecurity.API.Helpers;
using WeekOpdrachtSecurity.API.Models;
using WeekOpdrachtSecurity.API.Repos;

namespace WeekOpdrachtSecurity.API.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Register(RegisterRequest newuserrequest);

        User BlockOrUnblockUser(string username);
    }

    public class UserService : IUserService
    {

        
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        public List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };

        private readonly AppSettings _appSettings;
        private readonly IUserRepo _userRepo;

        public UserService(IOptions<AppSettings> appSettings, IUserRepo userRepo)
        {
            _appSettings = appSettings.Value;
            _userRepo = userRepo;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepo.GetAllUsers().SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public User Register(RegisterRequest newuserrequest)
        {
            User user = new User();

            user.Username = newuserrequest.Username;
            user.Password = newuserrequest.Password;
            user.FirstName = newuserrequest.FirstName;
            user.LastName = newuserrequest.LastName;
            //user.IsAdmin = newuserrequest.IsAdmin;
            //user.IsBlocked = newuserrequest.IsBlocked;
            user.UserType = newuserrequest.UserType;

            _userRepo.AddUser(user);

            return user;
        }

        public User BlockOrUnblockUser(string username)
        {
            var user = _userRepo.GetUserByUserName(username);

            if (user.IsBlocked == false)
            user.IsBlocked = true;

            else
            user.IsBlocked = false;

            _userRepo.UpdateUser(user);
            return user;

        }

        public User GetById(int id)
        {
            return _userRepo.GetUserById(id);
        }

        // helper methods

        public IEnumerable<User> GetAll()
        {
            return _userRepo.GetAllUsers();
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}