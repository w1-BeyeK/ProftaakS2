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

        public bool ActiveTreatmentTypeByIdAndActive(long id, bool active)
        {
            return context.ActiveTreatmentTypeByIdAndActive(id, active);
        }

        public List<Treatment> GetTreatments()
        {
            return context.GetTreatments();
        }

        public List<Treatment> GetTreatmentsByPatient(long id)
        {
            return context.GetTreatmentsByPatient(id);
        }

        public Treatment GetTreatmentById(long id)
        {
            return context.GetTreatmentById(id);
        }

        //List<Treatment> GetTreatments();
    }
}
