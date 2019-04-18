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
        public List<Patient> patients = new List<Patient>();

        public long Insert(Patient patient)
        {
            if (patients.Count > 0)
            {
                patients.OrderBy(d => d.Id);
                patient.Id = patients.Last().Id + 1;
            }
            else
            {
                patient.Id = 1;
            }
            patients.Add(patient);
            return patient.Id;
        }

        public bool Delete(Patient patient)
        {
            patients.FirstOrDefault(t => t.Id == patient.Id).Active = patient.Active;
            return true;
        }

        Patient IUniversalGenerics<Patient>.GetById(long id)
        {
            return patients.Find(t => t.Id == id);
        }

        List<Patient> IUniversalGenerics<Patient>.GetAll()
        {
            return patients.FindAll(t => t.Active == true);
        }

        public List<Patient> GetByDoctor(long id)
        {
            //throw new NotImplementedException();
            //Is not realy possible in TestContext...
            return patients;
        }

        public Patient LoginPatient(string username, string password)
        {
            Patient patient = patients.FirstOrDefault(p => p.UserName == username && p.Password == password);

            if (patient == null)
                throw new KeyNotFoundException("No patient found");

            return patient;
        }

        public bool Update(Patient patient)
        {
            int index = patients.FindIndex(p => p.Id == patient.Id);
            if (index > 0)
            {
                patients[index].PhoneNumber = patient.PhoneNumber;
                patients[index].PrivAdress = patient.PrivAdress;
                patients[index].PrivBirthDate = patient.PrivBirthDate;
                patients[index].PrivContactPersonName = patient.PrivContactPersonName;
                patients[index].PrivContactPersonPhone = patient.PrivContactPersonPhone;
                patients[index].PrivGender = patient.PrivGender;
                patients[index].PrivMail = patient.PrivMail;
                patients[index].PrivPhoneNumber = patient.PrivPhoneNumber;
                patients[index].UserName = patient.UserName;
                patients[index].Zipcode = patient.Zipcode;
                return patients.Exists(p => p == patient);
            }
            return false;
        }
    }
}
