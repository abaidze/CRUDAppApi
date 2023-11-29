using AutoMapper;
using CrudApp.Core;
using CrudApp.Repository;
using CrudApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Services.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly CrudAppContext _context;




        public UserRepository(CrudAppContext context)
        {
            _context = context;

        }
        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(c => c.Id == id);

        }

        public UserProfile GetUserProfile(int userId)
        {
            return _context.UserProfiles.FirstOrDefault(c => c.UserId == userId);

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(c => c.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public User ValidateUser(string userName, string password)
        {
            return _context.Users.FirstOrDefault(c => c.Username == userName && c.Password == password);

        }
    }
}
