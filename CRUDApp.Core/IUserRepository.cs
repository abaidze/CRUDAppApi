using CrudApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Core
{
    public interface IUserRepository
    {
        User ValidateUser(string userName, string password);

        ICollection<User> GetUsers();
        User GetUser(int id);
        UserProfile GetUserProfile(int userId);
        bool UserExists(int id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();

    }

}
