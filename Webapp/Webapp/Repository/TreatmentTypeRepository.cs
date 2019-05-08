using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class TreatmentTypeRepository
    {
        /// <summary>
        /// Context where queries are executed/actions are performed
        /// </summary>
        private readonly ITreatmentTypeContext context;

        public TreatmentTypeRepository(ITreatmentTypeContext context)
        {
            this.context = context ?? throw new NullReferenceException("Het behandelingsTypeContext is leeg.");
        }

        /// <summary>
        /// Add treatmenttype in database
        /// </summary>
        /// <param name="treatment"></param>
        /// <returns></returns>
        public long Insert(TreatmentType treatment)
        {
            // Insert through context
            if (treatment == null)
            {
                throw new NullReferenceException("De behandelingsType is leeg.");
            }
            return context.Insert(treatment);
        }
        
        /// <summary>
        /// Update treatmenttype in database
        /// </summary>
        /// <param name="treatment"></param>
        /// <returns></returns>
        public bool Update(TreatmentType treatment)
        {
            // Update through context
            if (treatment == null)
            {
                throw new NullReferenceException("De behandelingsType is leeg.");
            }
            return context.Update(treatment);
        }

        /// <summary>
        /// Update treatmenttype to active = 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            // Set treatmenttype inactive in database
            if (id < 1)
            {
                throw new NullReferenceException("De behandelingsTypeId is leeg.");
            }
            return context.Delete(GetById(id));
        }

        /// <summary>
        /// Returns a list of treatment types without filter
        /// </summary>
        /// <returns></returns>
        public List<TreatmentType> GetAll()
        {
            return context.GetAll();
        }

        /// <summary>
        /// Returns single instance of TreatmentType based on primary key (id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TreatmentType GetById(long id)
        {
            if (id < 1)
            {
                throw new NullReferenceException("De behandelingsTypeId is leeg.");
            }
            return context.GetById(id);
        }
    }
}
