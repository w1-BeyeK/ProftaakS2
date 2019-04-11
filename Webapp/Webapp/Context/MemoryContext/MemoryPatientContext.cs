using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MemoryContext
{
    public class MemoryPatientContext : BaseMemoryContext, IPatientContext
    {
        public long Insert(Patient patient)
        {
            //TODO : surch id
            patients.Add(patient);
            return patient.Id;
        }

        public bool Delete(Patient patient)
        {
                patients.FirstOrDefault(t => t.Id == patient.Id).Active = patient.Active;
                return true;
            return false;
        }

        public Patient GetById(long id)
        {
            return patients.Find(t => t.Id == id);
        }

        public List<Patient> GetAll()
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
            try
            {
                patients.FirstOrDefault(p => p.Id == patient.Id).Active = patient.Active;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
