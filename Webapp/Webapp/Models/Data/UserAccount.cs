using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public enum Gender { Male, Female };
    public class UserAccount : BaseAccount
    {
        public DateTime Birth { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public bool Active { get; set; }
        public Gender Gender { get; set; }

        public UserAccount()
        {

        }

        public virtual void AddComment()
        {

        }

        public virtual void ChangePersonalData()
        {

        }

        public virtual void ShowTreatments()
        {

        }

    }
}
