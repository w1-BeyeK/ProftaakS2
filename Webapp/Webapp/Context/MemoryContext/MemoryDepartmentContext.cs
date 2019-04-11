using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryDepartmentContext : BaseMemoryContext, IDepartmentContext
    {
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
            return new List<Department>(institutions.Find(t => t.Id == id).Departments);
        }

        public Department GetById(long id)
        {
            return departments.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(Department department)
        {

            //
            return true;
        }

        public bool AddDoctorToDepartment(long departmentId, long doctorId)
        {
            throw new NotImplementedException();
        }

        //TODO : GetAllByInstitution
        public List<Department> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
