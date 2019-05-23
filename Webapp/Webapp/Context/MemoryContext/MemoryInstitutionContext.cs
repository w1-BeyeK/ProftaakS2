using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryInstitutionContext : IInstitutionContext
    {
        public long Insert(Institution institution)
        {
            if (BaseMemoryContext.institutions.Count > 0)
            {
                BaseMemoryContext.institutions.OrderBy(d => d.Id);
                institution.Id = BaseMemoryContext.institutions.Last().Id + 1;
            }
            else
            {
                institution.Id = 1;
            }
            BaseMemoryContext.institutions.Add(institution);
            return institution.Id;
        }

        public bool AddDepartmentToInstitution(long institutionId, long departmentId)
        {
            if (BaseMemoryContext.departments.Exists(t => t.Id == departmentId) && BaseMemoryContext.institutions.Exists(t => t.Id == institutionId))
            {
                Department department = BaseMemoryContext.departments.Find(t => t.Id == departmentId);
                BaseMemoryContext.institutions.Find(t => t.Id == institutionId).Departments.Add(department);
                return true;
            }
            return false;
        }

        public bool Update(Institution institution)
        {
            if (BaseMemoryContext.institutions.Exists(i => i.Id == institution.Id))
            {
                int index = BaseMemoryContext.institutions.FindIndex(i => i.Id == institution.Id);
                BaseMemoryContext.institutions[index] = institution;
                return BaseMemoryContext.institutions.Exists(i => i == institution);
            }
            return false;
        }

        public List<Institution> GetAll()
        {
            return BaseMemoryContext.institutions;
        }

        public Institution GetById(long id)
        {
            return BaseMemoryContext.institutions.FirstOrDefault(i => i.Id == id);
        }

        public bool Delete(long id, bool active)
        {
            BaseMemoryContext.institutions.FirstOrDefault(i => i.Id == id).Active = active;
            return true;
        }
    }
}
