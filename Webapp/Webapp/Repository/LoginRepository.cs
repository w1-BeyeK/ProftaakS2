using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Exceptions;

namespace Webapp.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IContext context;

        public LoginRepository(IContext context)
        {
            this.context = context;
        }

        public LoginResult Login(string username, string password)
        {
            return new LoginResult()
            {
                Id = 1,
                Name = "Kevin",
                Type = "patient"
            };

            throw new UserNotFoundException("No user found with these credentials");
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
