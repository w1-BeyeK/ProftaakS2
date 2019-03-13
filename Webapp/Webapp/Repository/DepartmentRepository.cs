using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class DepartmentRepository
    {
        IContext context;

        public bool AddDepartment(Department department)
        {
            return context.AddDepartment();
        }

        public bool EditDepartment(Department department)
        {
            return context.EditDepartment(department);
        }

        /// <summary>
        /// Used both to activate and deactive Departments.
        /// </summary>
        public bool ActivateDepartment(Department department, bool activate)
        {
            return context.ActivateDepartment(department, activate);
        }

        /// <summary>
        /// Shows all departments of an institution.
        /// </summary>
        /// <param name="institution"></param>
        public List<Department> ShowDepartments(Institution institution)
        {
            return context.ShowDepartments(institution);
        }

        /// <summary>
        /// Shows all departments of a doctor.
        /// </summary>
        /// <param name="doctor"></param>
        public List<Department> ShowDepartments(Institution institution, Doctor doctor)
        {
            return context.ShowDepartments(institution, doctor);
        }

        /// <summary>
        /// Assign a doctor at a department
        /// </summary>
        public bool AssignDoctor(Department department, Doctor doctor)
        {
            return context.AssignDoctor(department, doctor);
        }
    }
}
