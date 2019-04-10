using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public interface IDoctorContext //: IUniversalContext<Doctor>
    {
        bool Insert(Doctor doctor);
        bool Update(long id, Doctor doctor);
        bool ActiveDoctorByIdAndActive(long id, bool active);
        List<Doctor> GetAllDoctors();
        List<Doctor> GetAllDoctorsByDepartmentId(long id);
        List<Doctor> GetAllDoctorsByInstitutionId(long id);
        Doctor GetById(long id);
    }
}
