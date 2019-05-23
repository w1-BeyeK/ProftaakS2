using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryTreatmentContext : ITreatmentContext
    {
        //TODO : Do we want this???
        public long Insert(Treatment treatment)
        {
            if (BaseMemoryContext.treatments.Count > 0)
            {
                BaseMemoryContext.treatments.OrderBy(t => t.Id);
                Treatment treat = BaseMemoryContext.treatments.Last();
                treatment.Id = treat.Id;
                BaseMemoryContext.treatments.Add(treatment);
                return treatment.Id;
            }
            return -1;
        }

        public long Insert(Treatment treatment, long treatmentTypeId, long doctorId, long patientId)
        {
            int patientIndex = BaseMemoryContext.patients.FindIndex(t => t.Id == patientId);
            int doctorIndex = BaseMemoryContext.doctors.FindIndex(t => t.Id == doctorId);
            int treatmentTypeIndex = BaseMemoryContext.treatmentTypes.FindIndex(t => t.Id == treatmentTypeId);

            if (patientIndex >= 0 && doctorIndex >= 0 && treatmentTypeId >= 0)
            {
                treatment.Patient = BaseMemoryContext.patients[patientIndex];
                treatment.Doctor = BaseMemoryContext.doctors[doctorIndex];
                treatment.TreatmentType = BaseMemoryContext.treatmentTypes[treatmentTypeIndex];

                long id = 0;
                if (BaseMemoryContext.treatments.Count > 0)
                {
                    BaseMemoryContext.treatments.OrderBy(t => t.Id);
                    long idMax = BaseMemoryContext.treatments.Last().Id;
                    id = idMax;
                }
                treatment.Id = id;

                BaseMemoryContext.treatments.Add(treatment);
                return treatment.Id;
            }
            return -1;
        }

        public bool Update(Treatment treatment)
        {
            if (BaseMemoryContext.treatments.Exists(t => t.Id == treatment.Id))
            {
                int index = BaseMemoryContext.treatments.FindIndex(t => t.Id == treatment.Id);
                BaseMemoryContext.treatments[index] = treatment;
                return BaseMemoryContext.treatments.Exists(t => t == treatment);
            }
            return false;
        }

        Treatment IUniversalGenerics<Treatment>.GetById(long id)
        {
            return BaseMemoryContext.treatments.Where(t => t.Id == id).FirstOrDefault();
        }

        List<Treatment> ITreatmentContext.GetByDoctor(long id)
        {
            return new List<Treatment>(BaseMemoryContext.treatments.FindAll(t => t.Doctor.Id == id));
        }

        public List<Treatment> GetByPatient(long id)
        {
            return BaseMemoryContext.treatments.FindAll(t => t.Patient.Id == id);
        }

        //TODO : Do we want this???
        List<Treatment> IUniversalGenerics<Treatment>.GetAll()
        {
            throw new NotImplementedException();
        }

        //TODO : Do we want this???
        public bool Delete(Treatment obj)
        {
            throw new NotImplementedException();
        }

        public bool CheckTreatmentRelationship(long doctorId, long patientId)
        {
            return BaseMemoryContext.treatments.Exists(t => t.DoctorId == doctorId && t.PatientId == patientId /*&& t.EndDate >= DateTime.Today.AddYears(-1)*/);
        }
    }
}
