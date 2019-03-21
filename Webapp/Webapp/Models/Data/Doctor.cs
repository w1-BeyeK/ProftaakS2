using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Doctor : UserAccount
    {
        //TODO : Moet dit in de constructor?
        //TODO : Moet dit ook in Classendiagram???
        public string Function { get; set; }
        public long EmployeeNumber { get; set; }

        public Doctor(int id, string userName, string email) : base(id, userName, email)
        {
            Role = "doctor";
            EmployeeNumber = Id;
        }

        public Doctor(long id, string userName, string email, string password, string name, DateTime birth, string phoneNumber, string mail, bool active, Gender gender) : base(id, userName, email, password, name, birth, phoneNumber, mail, active, gender)
        {
            Role = "doctor";
            EmployeeNumber = Id;
        }
    }
}
