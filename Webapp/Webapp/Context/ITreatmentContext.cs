using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public interface ITreatmentContext : IUniversalContext<Treatment>
    { 
        //bool Insert(Treatment treatment, long treatmentType, long doctorId, long patientId);
        //Activate??? do we need that???
        //Get all? Can you get ALL treatments of all doctors?
        List<Treatment> GetByDoctorId(long id);
        List<Treatment> GetByPatientId(long id);
    }
}
