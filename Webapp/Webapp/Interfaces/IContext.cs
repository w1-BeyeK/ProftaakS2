using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Models.Data;

namespace Webapp.Interfaces
{
    public interface IContext
    {
        bool ActivateDepartment(Department department, bool activate);
        bool ActivateDoctor(Doctor doctor, bool activate);
        bool ActivateInstitution(Institution institution, bool activate);
        bool AddComment(Comment comment);
        bool AddDoctor();
        bool AddDepartment();
        bool AddInstitution(Institution institution);
        bool AddTreatment(Treatment treatment);
        bool AddTreatmentType(TreatmentType treatmentType);
        bool AssignDoctor(Department department, Doctor doctor);
        bool EditDepartment(Department department);
        bool EditDoctor(Doctor doctor);
        bool EditDoctorPrivacy(Doctor doctor);
        bool EditPatient(Patient patient);
        bool EditPatientPrivacy(Patient patient);
        bool EditInstitution(Institution institution);
        bool EditTreatment(Treatment treatment);
        bool EditTreatmentType(TreatmentType treatmentType);
        Administrator LoginAdmin(string username, string password);
        Doctor LoginDoctor(string username, string password);
        Patient LoginPatient(string username, string password);
        List<Department> ShowDepartments(Institution institution);
        List<Department> ShowDepartments(Institution institution, Doctor doctor);
        List<Doctor> ShowDoctors(Department department);
        List<Doctor> ShowDoctors(Patient patient);
        List<Patient> ShowPatients(Doctor doctor);
        List<Treatment> ShowTreatments(Patient patient);
        List<Treatment> ShowTreatments(Doctor doctor);
        List<TreatmentType> ShowTreatmentTypes(Department department);
    }
}
