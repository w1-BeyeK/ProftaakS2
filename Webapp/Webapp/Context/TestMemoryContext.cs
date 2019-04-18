using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context
{
    
    public class TestMemoryContext : BaseMemoryContext, ICommentContext, IDepartmentContext, IDoctorContext, IInstitutionContext, IPatientContext, ITreatmentContext, ITreatmentTypeContext
    {
        public List<Comment> Insert(Comment comment)
        {
            if (treatments.Exists(t => t.Id == comment.TreatmentId))
            {
                if (treatments.Find(t => t.Id == comment.TreatmentId).Comments.Count > 0)
                {
                    treatments.Find(t => t.Id == comment.TreatmentId).Comments.OrderBy(c => c.Id);
                    comment.Id = treatments.Find(t => t.Id == comment.TreatmentId).Comments.Last().Id + 1;
                }
                else
                {
                    comment.Id = 1;
                }
                treatments.Find(t => t.Id == comment.TreatmentId).Comments.Add(comment);
                return new List<Comment>(treatments.Find(t => t.Id == comment.TreatmentId).Comments.ToList());
            }
            return null;
        }

        List<Comment> ICommentContext.GetByTreatment(long id)
        {
            return treatments.Find(t => t.Id == id).Comments;
        }

        public bool Delete(Department department)
        {
            departments.FirstOrDefault(d => d.Id == department.Id).Active = department.Active;
            return true;
        }

        public long Insert(Department department)
        {
            departments.Add(department);
            return department.Id;
        }

        public List<Department> GetByInstitution(long id)
        {
            return new List<Department>(institutions.Find(t => t.Id == id).Departments);
        }

        Department IUniversalGenerics<Department>.GetById(long id)
        {
            return departments.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(Department department)
        {
            if (departments.Exists(t => t.Id == department.Id))
            {
                int index = treatments.FindIndex(t => t.Id == department.Id);
                departments[index] = department;
                return departments.Exists(d => d == department);
            }
            return false;
        }

        public bool AddDoctorToDepartment(long departmentId, long doctorId)
        {
            throw new NotImplementedException();
        }

        //TODO : GetAllByInstitution
        List<Department> IUniversalGenerics<Department>.GetAll()
        {
            return new List<Department>(departments.Where(p => p.Active));
        }

        public bool Delete(Doctor doctor)
        {
            int index = doctors.FindIndex(t => t.Id == doctor.Id);
            if (index >= 0)
            {
                doctors[index].Active = doctor.Active;
                return true;
            }
            return false;
        }

        public long Insert(Doctor doctor)
        {
            if (doctors.Count > 0)
            {
                doctors.OrderBy(d => d.Id);
                doctor.Id = doctors.Last().Id + 1;
            }
            else
            {
                doctor.Id = 1;
            }
            doctors.Add(doctor);
            return doctor.Id;
        }

        Doctor IUniversalGenerics<Doctor>.GetById(long id)
        {
            return doctors.FirstOrDefault(d => d.Id == id);
        }

        List<Doctor> IUniversalGenerics<Doctor>.GetAll()
        {
            return doctors;
        }

        public List<Doctor> GetByDepartment(long id)
        {
            //throw new NotImplementedException();
            //By department id!????????
            return doctors;
        }

        List<Doctor> IDoctorContext.GetByInstitution(long id)
        {
            List<Department> departmentDoctor = institutions.Find(t => t.Id == id).Departments;
            //Get all doctors of all the departments and distinct all double doctors
            throw new NotImplementedException();
        }

        public bool Update(Doctor doctor)
        {
            if (doctors.Exists(d => d.Id == doctor.Id))
            {
                int index = doctors.FindIndex(d => d.Id == doctor.Id);
                doctors[index] = doctor;
                return doctors.Exists(d => d == doctor);
            }
            return false;
        }

        public bool AddToDepartment(long departmentId, long doctorId)
        {
            throw new NotImplementedException();
        }

        public long Insert(Institution institution)
        {
            if (institutions.Count > 0)
            {
                institutions.OrderBy(d => d.Id);
                institution.Id = institutions.Last().Id + 1;
            }
            else
            {
                institution.Id = 1;
            }
            institutions.Add(institution);
            return institution.Id;
        }

        public bool AddDepartmentToInstitution(long institutionId, long departmentId)
        {
            if (departments.Exists(t => t.Id == departmentId) && institutions.Exists(t => t.Id == institutionId))
            {
                Department department = departments.Find(t => t.Id == departmentId);
                institutions.Find(t => t.Id == institutionId).Departments.Add(department);
                return true;
            }
            return false;
        }

        public bool Update(Institution institution)
        {
            if (institutions.Exists(i => i.Id == institution.Id))
            {
                int index = institutions.FindIndex(i => i.Id == institution.Id);
                institutions[index] = institution;
                return institutions.Exists(i => i == institution);
            }
            return false;
        }

        public List<Institution> GetAll()
        {
            return institutions;
        }

        public Institution GetById(long id)
        {
            return institutions.FirstOrDefault(i => i.Id == id);
        }

        public bool Delete(Institution obj)
        {
            institutions.FirstOrDefault(i => i.Id == obj.Id).Active = obj.Active;
            return true;
        }

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

        public long Insert(TreatmentType treatmentType)
        {
            if (treatmentTypes.Count > 0)
            {
                treatmentTypes.OrderBy(d => d.Id);
                treatmentType.Id = treatmentTypes.Last().Id + 1;
            }
            else
            {
                treatmentType.Id = 1;
            }
            treatmentTypes.Add(treatmentType);
            return treatmentType.Id;
        }

        public bool Update(TreatmentType treatmentType)
        {
            int index = treatmentTypes.FindIndex(t => t.Id == treatmentType.Id);
            if (index >= 0)
            {
                treatmentTypes[index] = treatmentType;
                return treatmentTypes.Exists(t => t == treatmentType);
            }
             return false;
        }

        public bool Delete(TreatmentType treatmentType)
        {
            if (treatmentTypes.Exists(t => t.Id == treatmentType.Id))
            {
                treatmentTypes.FirstOrDefault(t => t.Id == treatmentType.Id).Active = treatmentType.Active;
                return true;
            }
            return false;
        }

        List<TreatmentType> IUniversalGenerics<TreatmentType>.GetAll()
        {
            return treatmentTypes.FindAll(t => t.Active == true);
        }

        public List<TreatmentType> GetByActive(bool active)
        {
            return treatmentTypes.FindAll(t => t.Active == active);
        }

        TreatmentType IUniversalGenerics<TreatmentType>.GetById(long id)
        {
            return treatmentTypes.Find(t => t.Id == id);
        }
    }
}
