using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public interface IInstitutionContext //: IUniversalContext<Institution>
    { 
        bool Insert(Institution institution);
        bool AddDepartmentToInstitution(long institutionId, long departmentId);
        bool Update(long id, Institution institution);
        List<Institution> GetAllInstitutions();
        Institution GetById(long id);
    }
}
