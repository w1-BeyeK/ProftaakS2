using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Doctor : UserAccount
    {
        public string Function { get; set; }
        public long EmployeeNumber { get; set; }

        public Doctor(int id, string username, string email) : base(id, username, email)
        {
            Role = "doctor";
        }

        public Doctor(int id, string username, string email, string password) : base(id, username, email, password)
        {
            Role = "doctor";
        }

        public Doctor()
        {
            Role = "doctor";
        }
    }
}
