using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryTreatmentTypeContext : BaseMemoryContext, ITreatmentTypeContext
    {
        public long Insert(TreatmentType treatmentType)
        {
            //TODO : Surch for Id
            treatmentTypes.Add(treatmentType);
            return treatmentType.Id;
        }

        public bool Update(TreatmentType treatmentType)
        {
            TreatmentType oldTreatmentType = GetById(treatmentType.Id);
            oldTreatmentType = treatmentType;
            return true;
        }
        
        public bool Delete(TreatmentType treatmentType)
        {
            try
            {
                treatmentTypes.FirstOrDefault(t => t.Id == treatmentType.Id).Active = treatmentType.Active;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TreatmentType> GetAll()
        {
            return treatmentTypes.FindAll(t => t.Active == true);
        }

        public List<TreatmentType> GetByActive(bool active)
        {
            return treatmentTypes.FindAll(t => t.Active == active);
        }

        public TreatmentType GetById(long id)
        {
            return treatmentTypes.Find(t => t.Id == id);
        }





















        //Must be standing here because of Kevins code

        long IUniversalContext<TreatmentType>.Insert(TreatmentType obj)
        {
            throw new NotImplementedException();
        }
    }
}
