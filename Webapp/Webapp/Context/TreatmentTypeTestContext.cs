using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public class TreatmentTypeTestContext : BaseTestContext, ITreatmentTypeContext
    {
        public bool Insert(TreatmentType treatmentType)
        {
            treatmentTypes.Add(treatmentType);
            return true;
        }

        public bool Update(long id, TreatmentType treatmentType)
        {
            if (id != treatmentType.Id)
                return false;

            TreatmentType oldTreatmentType = GetById(id);
            oldTreatmentType = treatmentType;
            return true;
        }
        
        public bool ActiveTreatmentTypeByIdAndActive(long id, bool active)
        {
            int index = treatmentTypes.FindIndex(t => t.Id == id);
            if (index >= 0)
            {
                treatmentTypes[index].Active = active;
                return true;
            }
            return false;
        }

        public List<TreatmentType> GetAllActiveTreatmentTypes()
        {
            return treatmentTypes.FindAll(t => t.Active == true);
        }

        public List<TreatmentType> GetAllTreatmentTypesByActive(bool active)
        {
            return treatmentTypes.FindAll(t => t.Active == active);
        }

        public TreatmentType GetById(long id)
        {
            return treatmentTypes.Find(t => t.Id == id);
        }
    }
}
