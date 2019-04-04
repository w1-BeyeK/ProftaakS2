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
        public PatientRepository(IContext context) : base(context)
        {
        }

        //TODO : This is for testing, but we dont need this!!!
        /// <summary>
        /// This is not needed...
        /// </summary>
        public bool AddPatient(Patient patient)
        {
            return Context.AddPatient(patient);
        }

        /// <summary>
        /// A patient can update its data
        /// </summary>
        public bool UpdatePatient(long id, Patient patient)
        {
            return Context.UpdatePatient(id, patient);
        }

        //TODO: is this possible? Because the only moment you want this is when a patient dies!
        /// <summary>
        /// A patient can activate its account to inactive (or active)
        /// </summary>
        public bool ActivePatientByIdAndActive(long id, bool active)
        {
            return Context.ActivePatientByIdAndActive(id, active);
        }

        /// <summary>
        /// An administrator or doctor can get all active patients
        /// </summary>
        public List<Patient> GetAllActivePatients()
        {
            return Context.GetAllActivePatients();
        }

        /// <summary>
        /// Get a patient by its id
        /// </summary>
        public Patient GetPatientById(long id)
        {
            return Context.GetPatientById(id);
        }

        /// <summary>
        /// Get all patients which have a treatment with the doctorId
        /// </summary>
        List<Patient> GetAllPatientsByDoctorId(long id)
        {
            return Context.GetAllPatientsByDoctorId(id);
        }
    }
}
