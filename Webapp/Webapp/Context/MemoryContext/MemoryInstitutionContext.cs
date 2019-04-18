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
        public List<Institution> institutions = new List<Institution>();

        public long Insert(Institution institution)
        {
            if (institutions.Count > 0)
            {
                institutions.OrderBy(d => d.Id);
                institution.Id = institutions.Last().Id + 1;
            }
            else
            {
                institution.Id = 1;
            }
            institutions.Add(institution);
            return institution.Id;
        }

        public bool AddDepartmentToInstitution(long institutionId, long departmentId)
        {
            MemoryDepartmentContext dc = new MemoryDepartmentContext();
            if (dc.departments.Exists(t => t.Id == departmentId) && institutions.Exists(t => t.Id == institutionId))
            {
                Department department = dc.departments.Find(t => t.Id == departmentId);
                institutions.Find(t => t.Id == institutionId).Departments.Add(department);
                return true;
            }
            return false;
        }

        public bool Update(Institution institution)
        {
            if (institutions.Exists(i => i.Id == institution.Id))
            {
                int index = institutions.FindIndex(i => i.Id == institution.Id);
                institutions[index] = institution;
                return institutions.Exists(i => i == institution);
            }
            return false;
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
            institutions.FirstOrDefault(i => i.Id == obj.Id).Active = obj.Active;
            return true;
        }
    }
}
