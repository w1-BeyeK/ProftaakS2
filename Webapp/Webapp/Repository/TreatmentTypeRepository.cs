using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class TreatmentTypeRepository : BaseRepository
    {
        public TreatmentTypeRepository(IContext context) : base(context)
        {
        }

        /// <summary>
        /// An administrator can add a treatmentType
        /// </summary>
        public bool AddTreatmentType(TreatmentType treatment)
        {
            return context.AddTreatmentType(treatment);
        }

        /// <summary>
        /// An administrator can update a treatmentType by its id
        /// </summary>
        public bool UpdateTreatmentType(long id, TreatmentType treatment)
        {
            return context.UpdateTreatmentType(id, treatment);
        }

        /// <summary>
        /// An administrator can activate or deactivate a treatmentType by its id
        /// </summary>
        public bool ActiveTreatmentTypeByIdAndActive(long id, bool active)
        {
            return context.ActiveTreatmentTypeByIdAndActive(id, active);
        }

        /// <summary>
        /// An administrator or doctor can get all active treatmentTypes
        /// </summary>
        public List<TreatmentType> GetAllActiveTreatmentTypes()
        {
            return context.GetAllActiveTreatmentTypes();
        }

        /// <summary>
        /// An administrator or doctor can get all treatmentTypes by active
        /// </summary>
        public List<TreatmentType> GetAllTreatmentTypesByActive(bool active)
        {
            return context.GetAllTreatmentTypesByActive(active);
        }

        /// <summary>
        /// An administrator or doctor can add a treatmentType by its id
        /// </summary>
        public TreatmentType GetTreatmentTypeById(long id)
        {
            return context.GetTreatmentTypeById(id);
        }
    }
}
