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

        public bool AddTreatment(Treatment treatment)
        {
            return context.AddTreatment(treatment);
        }

        public bool UpdateTreatment(long id, Treatment treatment)
        {
            return context.UpdateTreatment(id, treatment);
        }

        public bool DeleteTreatment(long id)
        {
            return context.DeleteTreatment(id);
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
