using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class TreatmentType : Entity
    {
        public TreatmentType()
        { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<Department> Departments { get; set; }

        public TreatmentType(string name, string description, bool active = true)
        {
            Name = name;
            Description = description;
            Active = active;
        }

        //TODO: methodes maken
        public void AddDoctor(Doctor doctor)
        {
           
        }

        public void AddDepartment(Department department)
        {

        }

        public void AddTreatment(Treatment treatment)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
