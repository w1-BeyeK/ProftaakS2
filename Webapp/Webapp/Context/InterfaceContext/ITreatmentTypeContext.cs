using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.InterfaceContext
{
    public interface ITreatmentTypeContext : IUniversalGenerics<TreatmentType>
    {
        TreatmentType GetByTreatmentId(long id);
        //bool Insert(TreatmentType treatmentType);
        //bool Update(long id, TreatmentType treatmentType);
        //bool ActiveTreatmentTypeByIdAndActive(long id, bool active);
        //List<TreatmentType> GetAllActiveTreatmentTypes();
        //List<TreatmentType> GetAllTreatmentTypesByActive(bool active);
        //TreatmentType GetById(long id);
        List<TreatmentType> GetTreatmentTypesByDoctorId(long id);
    }
}
