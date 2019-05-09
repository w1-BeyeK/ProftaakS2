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
        }
        
        public BaseAccount(long id, string userName, string email, string name)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Name = name;
            NormalizedUserName = userName.ToUpper();
            NormalizedEmail = email.ToUpper();
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
