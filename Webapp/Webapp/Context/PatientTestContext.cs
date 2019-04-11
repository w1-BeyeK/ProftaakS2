using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    public class PatientTestContext : BaseTestContext, IPatientContext
    {
        public bool Insert(Patient patient)
        {
            patients.Add(patient);
            return true;
        }

        public bool ActivePatientByIdAndActive(long id, bool active)
        {
            int index = patients.FindIndex(t => t.Id == id);
            if (index >= 0)
            {
                patients[index].Active = active;
                return true;
            }
            return false;
        }

        public Patient GetById(long id)
        {
            return patients.Find(t => t.Id == id);
        }

        public List<Patient> GetAllActivePatients()
        {
            return patients.FindAll(t => t.Active == true);
        }

        public List<Patient> GetAllPatientsByDoctorId(long id)
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

        public bool Update(long id, Patient patient)
        {
            if (id != patient.Id)
                return false;
            
            foreach (Patient p in patients)
            {
                if(p.Id == id)
                {
                    patients.Remove(p);
                    patients.Add(patient);
                    break;
                }
            }
            return true;
        }
    }
}
