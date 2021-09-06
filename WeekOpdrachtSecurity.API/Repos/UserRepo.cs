using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeekOpdrachtSecurity.API.DbContexts;
using WeekOpdrachtSecurity.API.Entities;

namespace WeekOpdrachtSecurity.API.Repos
{
    public class UserRepo : IUserRepo
    {

        private readonly WeekOpdrachtDbContext _mBDbContext;

        public UserRepo(WeekOpdrachtDbContext mBDbContext)
        {
            _mBDbContext = mBDbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _mBDbContext.Users;
        }

        public User AddUser(User user)
        {
            var addUser = _mBDbContext.Users.Add(user);
            _mBDbContext.SaveChanges();
            return addUser.Entity;
        }

        public User GetUserById(int userId)
        {
            return _mBDbContext.Users.FirstOrDefault(c => c.Id == userId);
        }

        public User GetUserByUserName(string username)
        {
            return _mBDbContext.Users.FirstOrDefault(c => c.Username == username);

           
        }


        public User UpdateUser(User user)
        {
           var updateuser = _mBDbContext.Users.FirstOrDefault(c => c.Username == user.Username) ;

            updateuser = user;

            _mBDbContext.SaveChanges();

            return user;
        }
        
    }
}
