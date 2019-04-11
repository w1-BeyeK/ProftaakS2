using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class PatientRepository : BaseRepository
    {
        //private readonly IContext context;

        public PatientRepository(IContext context) : base(context)
        {
            //this.context = context;
        }

        //TODO : This is for testing, but we dont need this!!!
        /// <summary>
        /// This is not needed...
        /// </summary>
        public bool Add(Patient patient)
        {
            return context.AddPatient(patient);
        }

        /// <summary>
        /// A patient can update its data
        /// </summary>
        public bool Update(Patient patient)
        {
            return context.UpdatePatient(1, patient);
        }

        /// <summary>
        /// An administrator or doctor can get all active patients
        /// </summary>
        public List<Patient> GetAll()
        {
            return context.GetAllActivePatients();
        }

        /// <summary>
        /// Get a patient by its id
        /// </summary>
        public Patient GetById(long id)
        {
            return context.GetPatientById(id);
        }

        /// <summary>
        /// Get all patients which have a treatment with the doctorId
        /// </summary>
        List<Patient> GetByDoctor(long id)
        {
            return context.GetAllPatientsByDoctorId(id);
        }
    }
}
