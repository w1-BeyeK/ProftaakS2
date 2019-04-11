using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public interface IDoctorContext : IUniversalContext<Doctor>
    {
        List<Doctor> GetAllDoctorsByDepartmentId(long id);
        List<Doctor> GetAllDoctorsByInstitutionId(long id);
    }
}
