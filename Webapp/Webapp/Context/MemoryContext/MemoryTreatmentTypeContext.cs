using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryTreatmentTypeContext : ITreatmentTypeContext
    {
        public List<TreatmentType> treatmentTypes = new List<TreatmentType>();

        public long Insert(TreatmentType treatmentType)
        {
            if (treatmentTypes.Count > 0)
            {
                treatmentTypes.OrderBy(d => d.Id);
                treatmentType.Id = treatmentTypes.Last().Id + 1;
            }
            else
            {
                treatmentType.Id = 1;
            }
            treatmentTypes.Add(treatmentType);
            return treatmentType.Id;
        }

        public bool Update(TreatmentType treatmentType)
        {
            int index = treatmentTypes.FindIndex(t => t.Id == treatmentType.Id);
            if (index >= 0)
            {
                treatmentTypes[index] = treatmentType;
                return treatmentTypes.Exists(t => t == treatmentType);
            }
            return false;
        }

        public bool Delete(TreatmentType treatmentType)
        {
            if (treatmentTypes.Exists(t => t.Id == treatmentType.Id))
            {
                treatmentTypes.FirstOrDefault(t => t.Id == treatmentType.Id).Active = treatmentType.Active;
                return true;
            }
            return false;
        }

        List<TreatmentType> IUniversalGenerics<TreatmentType>.GetAll()
        {
            return treatmentTypes.FindAll(t => t.Active == true);
        }

        public List<TreatmentType> GetByActive(bool active)
        {
            return treatmentTypes.FindAll(t => t.Active == active);
        }

        TreatmentType IUniversalGenerics<TreatmentType>.GetById(long id)
        {
            return treatmentTypes.Find(t => t.Id == id);
        }
    }
}
