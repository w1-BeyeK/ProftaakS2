﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Administrator : BaseAccount
    {
        public Administrator(): base()
        { }

        public long EmployeeNumber { get; set; }

        public Administrator(long id, string username, string email) : base(id, username, email)
        {
            Role = "admin";
        }

        public Administrator(long id, string username, string email, string name) : base(id, username, email, name)
        {
            Role = "admin";
        }
    }
}
