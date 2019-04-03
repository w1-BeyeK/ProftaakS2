using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class DepartmentRepository : BaseRepository
    {
        public DepartmentRepository(IContext context) : base(context)
        {
        }

        public bool AddDepartment(Department department)
        {
            return Context.AddDepartment(department);
        }

        public bool EditDepartment(Department department)
        {
            return Context.UpdateDepartment(department.Id, department);
        }
    }
}
