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

        public bool AddTreatmentType(TreatmentType treatment)
        {
            return Context.AddTreatmentType(treatment);
        }
        
        public bool EditTreatmentType(TreatmentType treatment)
        {
            return Context.UpdateTreatmentType(treatment.Id, treatment);
        }

        /// <summary>
        /// Shows TreatmentTypes of a department
        /// </summary>
        /// <param name="department"></param>
        //public List<TreatmentType> ShowTreatmentTypes(Department department)
        //{
        //    return context.GetTrea(department);
        //}
    }
}
