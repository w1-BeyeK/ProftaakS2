using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Administrator : BaseAccount
    {
        public long EmployeeNumber { get; set; }

        public Administrator(int id, string username, string email) : base(id, username, email)
        {
            Role = "admin";
        }

        public Administrator(int id, string username, string email, string password) : base(id, username, email, password)
        {
            Role = "admin";
        }
    }
}
