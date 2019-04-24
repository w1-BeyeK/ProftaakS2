﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context;
using Webapp.Context.InterfaceContext;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class TreatmentRepository
    {
        private readonly ITreatmentContext context;

        public TreatmentRepository(ITreatmentContext context)
        {
            this.context = context;
        }

        //TODO: Verwerken in 1 object - geen extra parameters
        /// <summary>
        /// A doctor can add a treatment
        /// </summary>
        public long Insert(Treatment treatment, long treatmentType, long doctorId, long patientId)
        {
            return context.Insert(treatment);
        }

        /// <summary>
        /// A doctor can update a treatment
        /// </summary>
        public bool Update(Treatment treatment)
        {
            return context.Update(treatment);
        }

        /// <summary>
        /// A doctor can get its treatments
        /// </summary>
        public List<Treatment> GetByDoctor(long id)
        {
            return context.GetByDoctor(id);
        }

        /// <summary>
        /// A patient or doctor can get the treatments of that patient
        /// </summary>
        public List<Treatment> GetByPatient(long id)
        {
            return context.GetByPatient(id);
        }

        /// <summary>
        /// A doctor or patient can get a treatment by its id
        /// </summary>
        public Treatment GetById(long id)
        {
            return context.GetById(id);
        }
    }
}
