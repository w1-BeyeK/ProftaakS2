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
        //private readonly IContext context;

        public TreatmentRepository(IContext context) : base(context)
        {
            //this.context = context;
        }

        /// <summary>
        /// A doctor can add a treatment
        /// </summary>
        public bool Add(Treatment treatment, long treatmentType, long doctorId, long patientId)
        {
            return context.AddTreatment(treatment, treatmentType, doctorId, patientId);
        }

        /// <summary>
        /// A doctor can update a treatment
        /// </summary>
        public bool Update(Treatment treatment)
        {
            return context.UpdateTreatment(1, treatment);
        }

        /// <summary>
        /// A doctor can get its treatments
        /// </summary>
        public List<Treatment> GetByDoctor(long id)
        {
            return context.GetAllTreatmentsByDoctorId(id);
        }

        /// <summary>
        /// A patient or doctor can get the treatments of that patient
        /// </summary>
        public List<Treatment> GetByPatient(long id)
        {
            return context.GetAllTreatmentsByPatientId(id);
        }

        /// <summary>
        /// A doctor or patient can get a treatment by its id
        /// </summary>
        public Treatment GetById(long id)
        {
            return context.GetTreatmentById(id);
        }
    }
}
