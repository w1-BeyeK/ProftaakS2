using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Models
{
    public class DoctorDetailViewModel
    {
        public long EmployeeNumber { get; set; }
        public DateTime Birth { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool PrivMail { get; set; }
        public bool PrivPhonenumber { get; set; }
    }
}
