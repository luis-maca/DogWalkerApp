using DogWalkerApp.Application.Interfaces;
using DogWalkerApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalkerApp.Infrastructure.Services
{
    public class LoginService : ILoginService
    {
        private readonly DogWalkerDbContext _context;

        public LoginService(DogWalkerDbContext context)
        {
            _context = context;
        }

        public bool ValidateCredentials(string username, string password)
        {
            username = username.Trim().ToLower();
            return _context.Users.Any(u => u.Username.ToLower() == username && u.Password == password && u.IsActive);
        }
    }

}
