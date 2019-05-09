using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class BaseAccount : Entity
    {
        public BaseAccount()
        { }

        public string Role { get; set; }

        public long Id { get; set; }
        public long DoctorId { get; set; }
        public long PatientId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get { return UserName.ToUpper(); } set { UserName = value.ToUpper(); } }

        public BaseAccount(long id, string userName, string email)
        {
            Id = id;
            UserName = userName;
            Email = email;
            NormalizedUserName = userName.ToUpper();
            NormalizedEmail = email.ToUpper();
            Role = "admin";
        }
        
        public BaseAccount(long id, string userName, string email, string name)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Name = name;
            NormalizedUserName = userName.ToUpper();
            NormalizedEmail = email.ToUpper();
            Role = "admin";
        }

        public bool IsInRole(string roleName)
        {
            bool isInRole = false;

            if (DoctorId > 0 && roleName == "doctor")
                isInRole = true;
            else if (PatientId > 0 && roleName == "patient")
                isInRole = true;
            else if (PatientId == 0 && DoctorId == 0 && roleName == "admin")
                isInRole = true;

            return isInRole;
        }

        public string GetRole()
        {
            string role = "";
            if (DoctorId > 0)
                role = "doctor";
            else if (PatientId > 0)
                role = "patient";
            else if (PatientId == 0 && DoctorId == 0)
                role = "admin";
            return role;
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
