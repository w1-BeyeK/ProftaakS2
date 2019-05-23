using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryPatientContext : IPatientContext
    {
        public long Insert(Patient patient)
        {
            if (BaseMemoryContext.patients.Count > 0)
            {
                BaseMemoryContext.patients.OrderBy(d => d.Id);
                patient.Id = BaseMemoryContext.patients.Last().Id + 1;
            }
            else
            {
                patient.Id = 1;
            }
            BaseMemoryContext.patients.Add(patient);
            return patient.Id;
        }

        public bool Delete(Patient patient)
        {
            BaseMemoryContext.patients.FirstOrDefault(t => t.Id == patient.Id).Active = patient.Active;
            return true;
        }

        Patient IUniversalGenerics<Patient>.GetById(long id)
        {
            return BaseMemoryContext.patients.Find(t => t.Id == id);
        }

        List<Patient> IUniversalGenerics<Patient>.GetAll()
        {
            return BaseMemoryContext.patients.FindAll(t => t.Active == true);
        }

        public List<Patient> GetByDoctor(long id)
        {
            //throw new NotImplementedException();
            //Is not realy possible in TestContext...
            return BaseMemoryContext.patients;
        }

        public Patient LoginPatient(string username, string password)
        {
            Patient patient = BaseMemoryContext.patients.FirstOrDefault(p => p.UserName == username && p.Password == password);

            if (patient == null)
                throw new KeyNotFoundException("No patient found");

            return patient;
        }

        public bool Update(Patient patient)
        {
            int index = BaseMemoryContext.patients.FindIndex(p => p.Id == patient.Id);
            if (index > 0)
            {
                BaseMemoryContext.patients[index].Phone = patient.Phone;
                BaseMemoryContext.patients[index].PrivAdress = patient.PrivAdress;
                BaseMemoryContext.patients[index].PrivBirthDate = patient.PrivBirthDate;
                BaseMemoryContext.patients[index].PrivContactPersonName = patient.PrivContactPersonName;
                BaseMemoryContext.patients[index].PrivContactPersonPhone = patient.PrivContactPersonPhone;
                BaseMemoryContext.patients[index].PrivGender = patient.PrivGender;
                BaseMemoryContext.patients[index].PrivMail = patient.PrivMail;
                BaseMemoryContext.patients[index].PrivPhone = patient.PrivPhone;
                BaseMemoryContext.patients[index].UserName = patient.UserName;
                BaseMemoryContext.patients[index].Zipcode = patient.Zipcode;
                BaseMemoryContext.patients[index].HouseNumber = patient.HouseNumber;
                BaseMemoryContext.patients[index].ContactPersonPhone = patient.ContactPersonPhone;
                BaseMemoryContext.patients[index].ContactPersonName = patient.ContactPersonName;
                BaseMemoryContext.patients[index].Email = patient.Email;
                return true;
            }
            return false;
        }

        public long GetPatientIdByTreatmentId(long id)
        {
            var treatment = BaseMemoryContext.treatments.Find(t => t.Id == id);
            return BaseMemoryContext.patients.Find(p => p.Id == treatment.Id).Id;
        }
    }
}
