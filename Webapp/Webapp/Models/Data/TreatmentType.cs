using System;
using System.Collections.Generic;
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
        public List<Doctor> Doctors { get; set; }
        public List<Treatment> Treatments { get; set; }
        public long DepartmentId { get; internal set; }

        public TreatmentType(string name, string description, bool active = true)
        {
            Name = name;
            Description = description;
            Departments = new List<Department>();
            Doctors = new List<Doctor>();
            Treatments = new List<Treatment>();
            Active = active;
        }


        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
        }

        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public void AddTreatment(Treatment treatment)
        {
            Treatments.Add(treatment);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
