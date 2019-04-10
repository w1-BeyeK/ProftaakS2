using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class TreatmentRepository : BaseRepository
    {
        public TreatmentRepository(IContext context) : base(context)
        {
        }

        public bool AddTreatment(Treatment treatment, long doctorId, long patientId)
        {
            return context.AddTreatment(treatment, doctorId, patientId);
        }

        public bool UpdateTreatment(long id, Treatment treatment)
        {
            return context.UpdateTreatment(id, treatment);
        }

        public List<Treatment> GetTreatmentsByPatientId(long id)
        {
            return context.GetTreatmentsByPatientId(id);
        }

        public List<Treatment> GetTreatmentsByDoctorId(long id)
        {
            return context.GetTreatmentsByDoctorId(id);
        }

        public Treatment GetTreatmentById(long id)
        {
            return context.GetTreatmentById(id);
        }
    }
}
