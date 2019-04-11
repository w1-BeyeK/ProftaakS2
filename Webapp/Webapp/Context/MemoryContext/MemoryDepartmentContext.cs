using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryDepartmentContext : BaseTestContext, IDepartmentContext
    {
        public bool ActiveDepartmentByIdAndActive(long id, bool active)
        {
            int index = departments.FindIndex(t => t.Id == id);
            if (index >= 0)
            {
                departments[index].Active = active;
                return true;
            }
            return false;
        }

        public bool Insert(Department department)
        {
            departments.Add(department);
            return true;
        }

        public List<Department> GetByInstitutionId(long id)
        {
            return institutions.Find(t => t.Id == id).Departments;
        }

        public Department GetById(long id)
        {
            return departments.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(long id, Department department)
        {
            if (id != department.Id)
                return false;

            Department oldDepartment = GetById(id);
            oldDepartment = department;
            return true;
        }

        public bool AddDoctorToDepartment(long departmentId, long doctorId)
        {
            throw new NotImplementedException();
        }














        //Must be standing here because of Kevins code
        public List<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        long IUniversalContext<Department>.Insert(Department obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Department obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Department obj)
        {
            throw new NotImplementedException();
        }
    }
}
