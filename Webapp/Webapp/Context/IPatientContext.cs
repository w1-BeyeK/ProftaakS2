using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public interface IPatientContext //: IUniversalContext<Patient>
    {
        bool Insert(Patient patient);
        bool Update(long id, Patient patient);
        bool ActivePatientByIdAndActive(long id, bool active);
        List<Patient> GetAllActivePatients();
        Patient GetById(long id);
        List<Patient> GetAllPatientsByDoctorId(long id);
    }
}
