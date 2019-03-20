using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Department
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }

        public Department(string name, bool active, string description)
        {
            Name = name;
            Active = active;
            Description = description;
        }
    }
}
