using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public abstract class BaseAccount
    {
        public string Role { get; set; }

        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public BaseAccount()
        { }

        public BaseAccount(int id, string username, string email)
        {
            Id = id;
            UserName = username;
            Email = email;

            NormalizedUserName = UserName.ToUpper();
            NormalizedEmail = email.ToUpper();
        }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }
      
        public BaseAccount(long id, string userName, string email, string name)
        {
            Id = id;
            UserName = userName;
            Email = email;

            NormalizedUserName = UserName.ToUpper();
            NormalizedEmail = email.ToUpper();
            Name = name;
        }

        public string RatingPassword()
        {
            throw new NotImplementedException();
        }

        public virtual string ToString()
        {
            return "";
        }
    }
}
