using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Patient: UserAccount
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }

        public Patient(int id, string username, string email) : base(id, username, email)
        {
            Role = "patient";
        }

        public Patient(int id, string username, string email, string password) : base(id, username, email, password)
        {
            Role = "patient";
        }

        public int GetAge()
        {
            throw new NotImplementedException();
        }
    }
}
