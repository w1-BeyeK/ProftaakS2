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
        public long Insert(TreatmentType treatmentType)
        {
            if (BaseMemoryContext.treatmentTypes.Count > 0)
            {
                treatmentType.Id = BaseMemoryContext.treatmentTypes.OrderBy(t => t.Id).Last().Id + 1;
            }
            else
            {
                treatmentType.Id = 1;
            }
            BaseMemoryContext.treatmentTypes.Add(treatmentType);
            return treatmentType.Id;
        }

        public bool Update(TreatmentType treatmentType)
        {
            int index = BaseMemoryContext.treatmentTypes.FindIndex(t => t.Id == treatmentType.Id);
            if (index >= 0)
            {
                BaseMemoryContext.treatmentTypes[index] = treatmentType;
                return BaseMemoryContext.treatmentTypes.Exists(t => t == treatmentType);
            }
            return false;
        }

        public bool Delete(TreatmentType treatmentType)
        {
            if (BaseMemoryContext.treatmentTypes.Exists(t => t.Id == treatmentType.Id))
            {
                BaseMemoryContext.treatmentTypes.FirstOrDefault(t => t.Id == treatmentType.Id).Active = treatmentType.Active;
                return true;
            }
            return false;
        }

        List<TreatmentType> IUniversalGenerics<TreatmentType>.GetAll()
        {
            return BaseMemoryContext.treatmentTypes.FindAll(t => t.Active == true);
        }

        public List<TreatmentType> GetByActive(bool active)
        {
            return BaseMemoryContext.treatmentTypes.FindAll(t => t.Active == active);
        }

        TreatmentType IUniversalGenerics<TreatmentType>.GetById(long id)
        {
            return BaseMemoryContext.treatmentTypes.Find(t => t.Id == id);
        }
    }
}
