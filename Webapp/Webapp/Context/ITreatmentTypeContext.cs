using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public interface ITreatmentTypeContext : IUniversalContext<TreatmentType>
    {
        //bool Insert(TreatmentType treatmentType);
        //bool Update(long id, TreatmentType treatmentType);
        //bool ActiveTreatmentTypeByIdAndActive(long id, bool active);
        //List<TreatmentType> GetAllActiveTreatmentTypes();
        //List<TreatmentType> GetAllTreatmentTypesByActive(bool active);
        //TreatmentType GetById(long id);
    }
}
