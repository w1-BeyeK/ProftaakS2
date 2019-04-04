using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Interfaces
{
    public interface IContext
    {
        //Doctor and Department must be added to eachother!
        //Department to an institution must be added!

        #region Patient
        bool AddPatient(Patient patient);
        bool UpdatePatient(long id, Patient patient);
        bool ActivePatientByIdAndActive(long id, bool active);
        List<Patient> GetAllActivePatients();
        Patient GetPatientById(long id);
        List<Patient> GetPatientsByDoctorId(long id);
        #endregion

        #region Doctor
        bool AddDoctor(Doctor doctor);
        bool UpdateDoctor(long id, Doctor doctor);
        bool ActiveDoctorByIdAndActive(long id, bool active);
        List<Doctor> GetAllDoctorsByDepartmentId(long id);
        Doctor GetDoctorById(long id);
        #endregion

        #region Department
        bool AddDepartment(Department department);
        bool UpdateDepartment(long id, Department department);
        bool ActiveDepartmentByIdAndActive(long id, bool active);
        List<Department> GetDepartmentsByInstitutionId(long id);
        Department GetDepartmentById(long id);
        #endregion

        #region Institution
        bool AddInstitution(Institution institution);
        bool UpdateInstitution(long id, Institution institution);
        List<Institution> GetAllInstitutions();
        Institution GetInstitutionById(long id);
        #endregion

        //Renovation needed!
        #region TreatmentType
        bool AddTreatmentType(TreatmentType treatmentType);
        bool UpdateTreatmentType(long id, TreatmentType treatmentType);
        bool ActiveTreatmentTypeByIdAndActive(long id, bool active);
        List<TreatmentType> GetTreatmentTypes();
        List<TreatmentType> GetTreatmentTypesByActive(bool active);
        TreatmentType GetTreatmentTypeById(long id);
        #endregion

        #region Treatment
        bool AddTreatment(Treatment treatment, long doctorId, long patientId);
        bool UpdateTreatment(long id, Treatment Treatment);
        List<Treatment> GetTreatmentsByDoctorId(long id);
        List<Treatment> GetTreatmentsByPatientId(long id);
        Treatment GetTreatmentById(long id);
        #endregion

        #region Comment
        bool AddComment(Comment comment, long treatmentId);
        List<Comment> GetCommentsByTreatmentId(long treatmentId);
        #endregion
    }
}
