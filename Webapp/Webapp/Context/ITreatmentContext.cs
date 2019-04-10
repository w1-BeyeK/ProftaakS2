using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public interface ITreatmentContext //: IUniversalContext<Treatment>
    { 
        bool Insert(Treatment treatment, long treatmentType, long doctorId, long patientId);
        bool Update(long id, Treatment Treatment);
        List<Treatment> GetAllTreatmentsByDoctorId(long id);
        List<Treatment> GetAllTreatmentsByPatientId(long id);
        Treatment GetById(long id);
    }
}
