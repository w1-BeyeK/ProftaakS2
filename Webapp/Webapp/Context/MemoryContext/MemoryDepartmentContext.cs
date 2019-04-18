using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryDepartmentContext : IDepartmentContext
    {
        public List<Department> departments = new List<Department>();

        public bool Delete(Department department)
        {
            departments.FirstOrDefault(d => d.Id == department.Id).Active = department.Active;
            return true;
        }

        public long Insert(Department department)
        {
            departments.Add(department);
            return department.Id;
        }

        public List<Department> GetByInstitution(long id)
        {
            MemoryInstitutionContext ic = new MemoryInstitutionContext();
            return new List<Department>(ic.institutions.Find(t => t.Id == id).Departments);
        }

        Department IUniversalGenerics<Department>.GetById(long id)
        {
            return departments.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(Department department)
        {
            MemoryTreatmentContext tc = new MemoryTreatmentContext();
            if (departments.Exists(t => t.Id == department.Id))
            {
                int index = tc.treatments.FindIndex(t => t.Id == department.Id);
                departments[index] = department;
                return departments.Exists(d => d == department);
            }
            return false;
        }

        public bool AddDoctorToDepartment(long departmentId, long doctorId)
        {
            throw new NotImplementedException();
        }

        //TODO : GetAllByInstitution
        List<Department> IUniversalGenerics<Department>.GetAll()
        {
            return new List<Department>(departments.Where(p => p.Active));
        }
    }
}
