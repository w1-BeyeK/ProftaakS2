using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryTreatmentContext : BaseTestContext, ITreatmentContext
    {
        //TODO : Do we want this???
        public long Insert(Treatment treatment)
        {
            return -1;
        }

        public long Insert(Treatment treatment, long treatmentTypeId, long doctorId, long patientId)
        {
            int patientIndex = patients.FindIndex(t => t.Id == patientId);
            int doctorIndex = doctors.FindIndex(t => t.Id == doctorId);
            int treatmentTypeIndex = treatmentTypes.FindIndex(t => t.Id == treatmentTypeId);

            if (patientIndex >= 0 && doctorIndex >= 0 && treatmentTypeId >= 0)
            {
                treatment.Patient = patients[patientIndex];
                treatment.Doctor = doctors[doctorIndex];
                treatment.TreatmentType = treatmentTypes[treatmentTypeIndex];

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
                treatments[index].BeginDate = treatment.BeginDate;
                treatments[index].Comments = treatment.Comments;
                treatments[index].EndDate = treatment.EndDate;
                treatments[index].Patient.Name = treatment.Patient.Name;
                treatments[index].Name = treatment.Name;
                treatments[index].TreatmentType = treatment.TreatmentType;
                return true;
            }
            return false;
        }

        public Treatment GetById(long id)
        {
            return treatments.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<Treatment> GetByDoctor(long id)
        {
            return new List<Treatment>(treatments.FindAll(t => t.Doctor.Id == id));
        }

        public List<Treatment> GetByPatient(long id)
        {
            //return treatments.Where(t => t.Patient.Id == id).ToList();
            return treatments.FindAll(t => t.Patient.Id == id);
        }

        //TODO : Do we want this???
        public List<Treatment> GetAll()
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
