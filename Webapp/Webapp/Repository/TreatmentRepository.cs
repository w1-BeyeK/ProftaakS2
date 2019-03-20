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
        IContext context;

        public bool AddTreatment(Treatment treatment)
        {
            return context.AddTreatment(treatment);
        }

        public bool EditTreatment(Treatment treatment)
        {
            return context.EditTreatment(treatment);
        }

        /// <summary>
        /// Shows treatments of a patient
        /// </summary>
        /// <param name="patient"></param>
        public List<Treatment> ShowTreatments(Patient patient)
        {
            return context.ShowTreatments(patient);
        }

        /// <summary>
        /// Shows treatments of a doctor
        /// </summary>
        /// <param name="doctor"></param>
        public List<Treatment> ShowTreatments(Doctor doctor)
        {
            return context.ShowTreatments(doctor);
        }
    }
}
