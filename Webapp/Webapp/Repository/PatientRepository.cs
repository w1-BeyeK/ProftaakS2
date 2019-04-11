using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context;
using Webapp.Context.InterfaceContext;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class PatientRepository // : ICRUDRepository<T>
    {
        private readonly IPatientContext context;

        public PatientRepository(IPatientContext context)
        {
            this.context = context;
        }

        //TODO : This is for testing, but we dont need this!!!
        /// <summary>
        /// This is not needed...
        /// </summary>
        public long Add(Patient patient)
        {
            return context.Insert(patient);
        }

        /// <summary>
        /// A patient can update its data
        /// </summary>
        public bool Update(Patient patient)
        {
            return context.Update(patient);
        }

        /// <summary>
        /// An administrator or doctor can get all active patients
        /// </summary>
        public List<Patient> GetAll()
        {
            return context.GetAll();
        }

        /// <summary>
        /// Get a patient by its id
        /// </summary>
        public Patient GetById(long id)
        {
            return context.GetById(id);
        }

        /// <summary>
        /// Get all patients which have a treatment with the doctorId
        /// </summary>
        List<Patient> GetByDoctor(long id)
        {
            return context.GetByDoctor(id);
        }
    }
}
