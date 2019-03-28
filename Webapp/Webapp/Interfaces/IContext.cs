using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Interfaces
{
    public interface IContext
    {
        #region Patient
        bool AddPatient(Patient patient);
        bool UpdatePatient(long id, Patient patient);
        bool DeletePatientById(long id);
        List<Patient> GetPatients();
        Patient GetPatientById(long id);
        List<Patient> GetPatientsByDoctorId(long id);
        #endregion
        #region Doctor
        bool AddDoctor(Doctor doctor);
        bool UpdateDoctor(long id, Doctor doctor);
        bool DeleteDoctorById(long id);
        List<Doctor> GetDoctors();
        Doctor GetDoctorById(long id);
        #endregion
        #region Department
        bool AddDepartment(Department department);
        bool UpdateDepartment(long id, Department department);
        bool DeleteDepartmentById(long id);
        List<Department> GetDepartments();
        Department GetDepartmenById(long id);
        #endregion
        #region Institution
        bool AddInstitution(Institution institution);
        bool UpdateInstitution(long id, Institution institution);
        bool DeleteInstitutionById(long id);
        List<Institution> GetInstitutions();
        Institution GetInstitutionById(long id);
        #endregion
        #region TreatmentType
        bool AddTreatmentType(TreatmentType treatmentType);
        bool UpdateTreatmentType(long id, TreatmentType treatmentType);
        bool DeleteTreatmentTypeById(long id);
        List<TreatmentType> GetTreatmentTypes();
        TreatmentType GetTreatmentTypeById(long id);
        #endregion
        #region Treatment
        bool AddTreatment(Treatment treatment);
        bool UpdateTreatment(long id, Treatment Treatment);
        bool DeleteTreatmentById(long id);
        List<Treatment> GetTreatments();
        Treatment GetTreatmentById(long id);
        #endregion
        #region Comment
        bool AddComment(Comment comment);
        List<Comment> GetComments();
        Comment GetCommentById(long id);
        #endregion
        
    }
}
