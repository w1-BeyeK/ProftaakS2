using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Department : Entity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public long InstitutionId { get; set; }

        public Department()
        { }

        public Department(long id, string name, string description, bool active)
        {
            Id = id;
            Name = name;
            Description = description;
            Active = active;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
