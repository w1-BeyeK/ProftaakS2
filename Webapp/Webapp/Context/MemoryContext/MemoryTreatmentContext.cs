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
        public List<Treatment> treatments = new List<Treatment>();

        //TODO : Do we want this???
        public long Insert(Treatment treatment)
        {
            if (treatments.Count > 0)
            {
                treatments.OrderBy(t => t.Id);
                Treatment treat = treatments.Last();
                treatment.Id = treat.Id;
                treatments.Add(treatment);
                return treatment.Id;
            }
            return -1;
        }

        public long Insert(Treatment treatment, long treatmentTypeId, long doctorId, long patientId)
        {
            MemoryPatientContext pc = new MemoryPatientContext();
            MemoryDoctorContext dc = new MemoryDoctorContext();
            MemoryTreatmentTypeContext tc = new MemoryTreatmentTypeContext();
            int patientIndex = pc.patients.FindIndex(t => t.Id == patientId);
            int doctorIndex = dc.doctors.FindIndex(t => t.Id == doctorId);
            int treatmentTypeIndex = tc.treatmentTypes.FindIndex(t => t.Id == treatmentTypeId);

            if (patientIndex >= 0 && doctorIndex >= 0 && treatmentTypeId >= 0)
            {
                treatment.Patient = pc.patients[patientIndex];
                treatment.Doctor = dc.doctors[doctorIndex];
                treatment.TreatmentType = tc.treatmentTypes[treatmentTypeIndex];

                long id = 0;
                if (treatments.Count > 0)
                {
                    treatments.OrderBy(t => t.Id);
                    long idMax = treatments.Last().Id;
                    id = idMax;
                }
                treatment.Id = id;

                treatments.Add(treatment);
                return treatment.Id;
            }
            return -1;
        }

        public bool Update(Treatment treatment)
        {
            if (treatments.Exists(t => t.Id == treatment.Id))
            {
                int index = treatments.FindIndex(t => t.Id == treatment.Id);
                treatments[index] = treatment;
                return treatments.Exists(t => t == treatment);
            }
            return false;
        }

        Treatment IUniversalGenerics<Treatment>.GetById(long id)
        {
            return treatments.Where(t => t.Id == id).FirstOrDefault();
        }

        List<Treatment> ITreatmentContext.GetByDoctor(long id)
        {
            return new List<Treatment>(treatments.FindAll(t => t.Doctor.Id == id));
        }

        public List<Treatment> GetByPatient(long id)
        {
            return treatments.FindAll(t => t.Patient.Id == id);
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
    }
}
