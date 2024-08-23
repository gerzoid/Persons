using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public sealed class UserService
    {
        private List<User> _users = new() { new User() { FirstName = "Gerz", LastName = "Gerz", Id = 1, Password = "korobok", Username = "gerz", IsAdmin = true, UserRoles = new List<UserRole>() } };

        public UserService()
        {
            _users[0].UserRoles.Add(new UserRole() { Role = new Role() { Id = 1, Name = "Administrator" } });
        }

        public User Get(int id)
        {
            return _users.Where(d=>d.Id == id).First();
        }
        public List<User> Users()
        {
            return _users;
        }
    }
}
