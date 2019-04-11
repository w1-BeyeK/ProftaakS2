using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryInstitutionContext : BaseMemoryContext, IInstitutionContext
    {
        public long Insert(Institution institution)
        {
            //TODO : Give id
            institutions.Add(institution);
            return institution.Id;
        }

        public bool AddDepartmentToInstitution(long institutionId, long departmentId)
        {
            if (departments.Exists(t => t.Id == departmentId) && institutions.Exists(t => t.Id == institutionId))
            {
                Department department = departments.Find(t => t.Id == departmentId);
                institutions.Find(t => t.Id == institutionId).Departments.Add(department);
                return true;
            }
            return false;
        }

        public bool Update(Institution institution)
        {
            //TODO : Implement
            Institution oldInstitution = GetById(institution.Id);
            oldInstitution = institution;
            return true;
        }

        public List<Institution> GetAll()
        {
            return institutions;
        }

        public Institution GetById(long id)
        {
            return institutions.FirstOrDefault(i => i.Id == id);
        }

        public bool Delete(Institution obj)
        {
            throw new NotImplementedException();
        }
    }
}
