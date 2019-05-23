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

        public bool Delete(long id, bool active)
        {
            if (BaseMemoryContext.treatmentTypes.Exists(t => t.Id == id))
            {
                BaseMemoryContext.treatmentTypes.FirstOrDefault(t => t.Id == id).Active = active;
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
        public TreatmentType GetByTreatmentId(long id)
        {
            return BaseMemoryContext.treatmentTypes.Find(t => t.Id == id);
        }

        TreatmentType IUniversalGenerics<TreatmentType>.GetById(long id)
        {
            return BaseMemoryContext.treatmentTypes.Find(t => t.Id == id);
        }

        TreatmentType ITreatmentTypeContext.GetByTreatmentId(long id)
        {
            throw new NotImplementedException();
        }

        List<TreatmentType> ITreatmentTypeContext.GetTreatmentTypesByDoctorId(long id)
        {
            throw new NotImplementedException();
        }

        long IUniversalGenerics<TreatmentType>.Insert(TreatmentType obj)
        {
            throw new NotImplementedException();
        }

        bool IUniversalGenerics<TreatmentType>.Update(TreatmentType obj)
        {
            throw new NotImplementedException();
        }

        bool IUniversalGenerics<TreatmentType>.Delete(TreatmentType obj)
        {
            throw new NotImplementedException();
        }
    }
}
