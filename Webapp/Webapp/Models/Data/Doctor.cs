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
        public bool PrivMail { get; set; }
        public bool PrivPhoneNumber { get; set; }

        //TODO : Lijst met departments???

        public Doctor()
        {
            Role = "doctor";
            PrivMail = true;
            PrivPhoneNumber = true;
        }

        public Doctor(long id, string userName, string email, string name) : base((int)id, userName, email, name)
        {
            Role = "doctor";
            
        }

        public Doctor(long id, string userName, string email, string password, string name, DateTime birth, string phoneNumber, bool active, Gender gender) : base(id, userName, email, password, name, birth, phoneNumber, active, gender)
        {
            Role = "doctor";
            EmployeeNumber = Id;
            PrivMail = true;
            PrivPhoneNumber = true;
        }
        public int GetAge()
        {
            int age = (int)((DateTime.Today - Birth).Days / 365.25);
            return age;
        }
    }
}
