using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class DepartmentRepository
    {
        protected readonly IDepartmentContext context;

        public DepartmentRepository(IDepartmentContext context)
        {
            this.context = context;
        }

        public long Add(Department department)
        {
            return context.Insert(department);
        }

        public bool Update(Department department)
        {
            return context.Update(department);
        }

        public bool Delete(long id)
        {
            return context.Delete(GetById(id));
        }

        public Department GetById(long id)
        {
            return context.GetById(id);
        }

        public List<Department> GetAll()
        {
            return context.GetAll();
        }
    }
}
