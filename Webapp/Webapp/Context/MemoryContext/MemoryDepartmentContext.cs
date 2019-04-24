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
        public bool Delete(Department department)
        {
            BaseMemoryContext.departments.FirstOrDefault(d => d.Id == department.Id).Active = department.Active;
            return true;
        }

        public long Insert(Department department)
        {
            BaseMemoryContext.departments.Add(department);
            return department.Id;
        }

        public List<Department> GetByInstitution(long id)
        {
            return new List<Department>(BaseMemoryContext.institutions.Find(t => t.Id == id).Departments);
        }

        Department IUniversalGenerics<Department>.GetById(long id)
        {
            return BaseMemoryContext.departments.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(Department department)
        {
            if (BaseMemoryContext.departments.Exists(t => t.Id == department.Id))
            {
                int index = BaseMemoryContext.treatments.FindIndex(t => t.Id == department.Id);
                BaseMemoryContext.departments[index] = department;
                return BaseMemoryContext.departments.Exists(d => d == department);
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
            return new List<Department>(BaseMemoryContext.departments.Where(p => p.Active));
        }
    }
}
