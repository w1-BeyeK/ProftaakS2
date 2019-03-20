﻿using System;
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
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public BaseAccount()
        {
        }

        public BaseAccount(int id, string username, string email)
        {
            Id = id;
            UserName = username;
            Email = email;
        }

        public BaseAccount(int id, string username, string email, string password)
        {
            Id = id;
            UserName = username;
            Email = email;
            Password = password;
        }

        public string RatingPassword()
        {
            throw new NotImplementedException();
        }
    }
}
