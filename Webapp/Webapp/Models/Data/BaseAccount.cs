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

        //Deze moet wellicht weg? Ligt eraan wat handig is!
        public string NormalizedUserName { get; set; }

        public BaseAccount(long id, string userName, string email)
        {
            Id = id;
            UserName = userName;
            Email = email;
        }

        public BaseAccount(long id, string userName, string email, string password)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Password = password;
        }

        protected BaseAccount(long id, string userName, string email, string password, string name)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Password = password;
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
