using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.InterfaceContext
{
    public interface ITreatmentContext : IUniversalGenerics<Treatment>
    { 
        List<Treatment> GetByDoctor(long id);
        List<Treatment> GetByPatient(long id);
        bool CheckTreatmentRelationship(long doctorId, long patientId);
        bool PatientGiveAccessToDoctor(long treatmentId, bool access);
        List<Treatment> GetUnconfirmedTreatmentsByPatient(long patientId);
    }
}
