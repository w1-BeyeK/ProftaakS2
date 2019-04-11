using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public interface IDepartmentContext : IUniversalContext<Department>
    {
        //bool Insert(Department department);
        //bool Update(long id, Department department);
        //bool ActiveDepartmentByIdAndActive(long id, bool active);
        //List<Department> GetAllDepartmentsByInstitutionId(long id);
        //Department GetById(long id);
        ////TODO : In welke IContext moet deze???
        //bool AddDoctorToDepartment(long departmentId, long doctorId);
    }
}
