using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Department
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public Department(string name, string description, bool active)
        {
            Name = name;
            Description = description;
            Active = active;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        //TODO: Verwijder later
        public Department()
        {
        }
    }
}
