using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context;
using Webapp.Context.InterfaceContext;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class DepartmentRepository // : ICRUDRepository<T>
    {
        private readonly IDepartmentContext context;

        public DepartmentRepository(IDepartmentContext context)
        {
            this.context = context ?? throw new NullReferenceException("De afdelingContext is leeg.");
        }

        public long Insert(Department department)
        {
            if (department == null)
            {
                throw new NullReferenceException("De afdeling is leeg.");
            }
            return context.Insert(department);
        }

        public bool Update(Department department)
        {
            if (department == null)
            {
                throw new NullReferenceException("De afdeling is leeg.");
            }
            return context.Update(department);
        }

        public bool Delete(long id)
        {
            if (id < 1)
            {
                throw new NullReferenceException("Het afdelingId is leeg.");
            }
            return context.Delete(GetById(id));
        }
        
        public Department GetById(long id)
        {
            if (id < 1)
            {
                throw new NullReferenceException("Het afdelingId is leeg.");
            }
            return context.GetById(id);
        }

        public List<Department> GetAll()
        {
            return context.GetAll();
        }

        internal List<Department> GetForDoctor(long doctorId)
        {
            return context.GetForDoctor(doctorId);
        }
    }
}
