using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class DepartmentRepository
    {
        IContext context;

        public bool AddDepartment(Department department)
        {
            return context.AddDepartment(department);
        }

        public bool EditDepartment(Department department)
        {
            return context.UpdateDepartment(department.Id, department);
        }
    }
}
