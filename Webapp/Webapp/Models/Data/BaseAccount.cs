using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public abstract class BaseAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public BaseAccount()
        {

        }

        public void ShowPersonalData() { }
    }
}
