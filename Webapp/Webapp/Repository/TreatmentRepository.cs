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

        /// <summary>
        /// A doctor can add a treatment
        /// </summary>
        public bool AddTreatment(Treatment treatment, long doctorId, long patientId)
        {
            return Context.AddTreatment(treatment, doctorId, patientId);
        }

        /// <summary>
        /// A doctor can update a treatment
        /// </summary>
        public bool UpdateTreatment(long id, Treatment treatment)
        {
            return Context.UpdateTreatment(id, treatment);
        }

        /// <summary>
        /// A doctor can get its treatments
        /// </summary>
        public List<Treatment> GetAllTreatmentsByDoctorId(long id)
        {
            return Context.GetAllTreatmentsByDoctorId(id);
        }

        /// <summary>
        /// A patient or doctor can get the treatments of that patient
        /// </summary>
        public List<Treatment> GetAllTreatmentsByPatientId(long id)
        {
            return Context.GetAllTreatmentsByPatientId(id);
        }

        /// <summary>
        /// A doctor or patient can get a treatment by its id
        /// </summary>
        public Treatment GetTreatmentById(long id)
        {
            return Context.GetTreatmentById(id);
        }
    }
}
