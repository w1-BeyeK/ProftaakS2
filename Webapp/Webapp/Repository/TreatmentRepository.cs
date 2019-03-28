using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class TreatmentRepository
    {
        private readonly IContext context;

        public TreatmentRepository(IContext context)
        {
            this.context = context;
        }

        public bool AddTreatment(Treatment treatment, int doctorId, int patientId)
        {
            return context.AddTreatment(treatment, doctorId, patientId);
        }

        public List<Treatment> GetTreatmentsByDoctor(long id)
        {
            return context.GetTreatmentsByDoctor(id);
        }

        public List<Treatment> GetTreatmentsByPatient(long id)
        {
            return context.GetTreatmentsByPatient(id);
        }
    }
}
