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
            this.context = context ?? throw new NullReferenceException("De patiëntContext is leeg.");
        }

        //TODO : This is for testing, but we dont need this!!!
        /// <summary>
        /// This is not needed...
        /// </summary>
        public long Insert(Patient patient)
        {
            if (patient == null)
            {
                throw new NullReferenceException("De patiënt is leeg.");
            }
            return context.Insert(patient);
        }

        /// <summary>
        /// A patient can update its data
        /// </summary>
        public bool Update(Patient patient)
        {
            if (patient == null)
            {
                throw new NullReferenceException("De patiënt is leeg.");
            }
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
            if (id < 1)
            {
                throw new NullReferenceException("Het patiëntId is leeg.");
            }
            return context.GetById(id);
        }

        /// <summary>
        /// Get all patients which have a treatment with the doctorId
        /// </summary>
        public List<Patient> GetByDoctor(long id)
        {
            if (id < 1)
            {
                throw new NullReferenceException("Het dokterId is leeg.");
            }
            return context.GetByDoctor(id);
        }
    }
}
