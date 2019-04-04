using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Interfaces
{
    public interface IContext
    {
        bool AddDoctorToDepartment(long departmentId, long doctorId);

        #region Patient
        bool AddPatient(Patient patient);
        bool UpdatePatient(long id, Patient patient);
        bool ActivePatientByIdAndActive(long id, bool active);
        List<Patient> GetAllActivePatients();
        Patient GetPatientById(long id);
        List<Patient> GetAllPatientsByDoctorId(long id);
        #endregion

        #region Doctor
        bool AddDoctor(Doctor doctor);
        bool UpdateDoctor(long id, Doctor doctor);
        bool ActiveDoctorByIdAndActive(long id, bool active);
        List<Doctor> GetAllDoctors();
        List<Doctor> GetAllDoctorsByDepartmentId(long id);
        List<Doctor> GetAllDoctorsByInstitutionId(long id);
        Doctor GetDoctorById(long id);
        #endregion

        #region Department
        bool AddDepartment(Department department);
        bool UpdateDepartment(long id, Department department);
        bool ActiveDepartmentByIdAndActive(long id, bool active);
        List<Department> GetAllDepartmentsByInstitutionId(long id);
        Department GetDepartmentById(long id);
        #endregion

        #region Institution
        bool AddInstitution(Institution institution);
        bool AddDepartmentToInstitution(long institutionId, long departmentId);
        bool UpdateInstitution(long id, Institution institution);
        List<Institution> GetAllInstitutions();
        Institution GetInstitutionById(long id);
        #endregion

        //Renovation needed!
        #region TreatmentType
        bool AddTreatmentType(TreatmentType treatmentType);
        bool UpdateTreatmentType(long id, TreatmentType treatmentType);
        bool ActiveTreatmentTypeByIdAndActive(long id, bool active);
        List<TreatmentType> GetAllActiveTreatmentTypes();
        List<TreatmentType> GetAllTreatmentTypesByActive(bool active);
        TreatmentType GetTreatmentTypeById(long id);
        #endregion

        #region Treatment
        bool AddTreatment(Treatment treatment, long doctorId, long patientId);
        bool UpdateTreatment(long id, Treatment Treatment);
        List<Treatment> GetAllTreatmentsByDoctorId(long id);
        List<Treatment> GetAllTreatmentsByPatientId(long id);
        Treatment GetTreatmentById(long id);
        #endregion

        #region Comment
        bool AddComment(Comment comment, long treatmentId);
        List<Comment> GetAllCommentsByTreatmentId(long treatmentId);
        #endregion
    }
}
