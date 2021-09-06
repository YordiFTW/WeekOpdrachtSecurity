using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeekOpdrachtSecurity.API.Entities;

namespace WeekOpdrachtSecurity.API.Repos
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers();
        User AddUser(User user);

        User GetUserById(int userId);
        User GetUserByUserName(string username);

        User UpdateUser(User user);
    }
}
