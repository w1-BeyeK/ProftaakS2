using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public class InstitutionTestContext : BaseTestContext, IInstitutionContext
    {
        public bool Insert(Institution institution)
        {
            institutions.Add(institution);
            return true;
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

        public bool Update(long id, Institution institution)
        {
            if (id != institution.Id)
                return false;

            Institution oldInstitution = GetInstitutionById(id);
            oldInstitution = institution;
            return true;
        }

        public List<Institution> GetAllInstitutions()
        {
            return institutions;
        }

        public Institution GetById(long id)
        {
            return institutions.FirstOrDefault(i => i.Id == id);
        }
    }
}
