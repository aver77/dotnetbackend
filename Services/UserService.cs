using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3labBackEnd.Models;
using _3labBackEnd.Models.ViewModels.UserViewModel;

namespace _3labBackEnd.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(GetUserByIdVM userModel);
        bool SaveCreationUser(CreateUserVM userModel);
        bool DeleteUser(DeleteUserVM userModel);
    }

    public class UserService : IUserService
    {
        //Database
        private readonly UserDbContext _context;
        public UserService(UserDbContext context)
        {
            _context = context;
        }
        public List<User> GetAllUsers()
        {
            return _context.CurrentUsers.ToList();
        }
        public User GetUserById(GetUserByIdVM userModel)
        {
            return _context.CurrentUsers.First(id => id.Id == userModel.Id);
        }

        public bool SaveCreationUser(CreateUserVM userModel)
        {
            try
            {
                var user = new User() { Id = userModel.Id, UserName = userModel.UserName, UserProfession = userModel.UserProfession };
                _context.CurrentUsers.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }

        public bool DeleteUser(DeleteUserVM userModel)
        {
            try
            {
                var entity = _context.CurrentUsers.First(id => id.Id == userModel.Id);
                _context.CurrentUsers.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
