using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Identity
{
    public interface IIdentityService
    {
        User Authenticate(string login, string password);
        User GetById(int id);
        User? GetCurrentUser();
        string GenerateJwtToken(User user);
    }
}
