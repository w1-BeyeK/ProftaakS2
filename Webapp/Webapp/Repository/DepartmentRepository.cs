﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class DepartmentRepository : BaseRepository
    {
        public DepartmentRepository(IContext context) : base(context)
        {
        }

        /// <summary>
        /// An Administrator can add a department
        /// </summary>
        public bool AddDepartment(Department department)
        {
            return context.AddDepartment(department);
        }

        /// <summary>
        /// An administrator can add a doctor to a department
        /// </summary>
        bool AddDoctorToDepartment(long departmentId, long doctorId)
        {
            return context.AddDoctorToDepartment(departmentId, doctorId);
        }

        /// <summary>
        /// An Administrator can update a department
        /// </summary>
        public bool UpdateDepartment(long id, Department department)
        {
            return context.UpdateDepartment(id, department);
        }

        /// <summary>
        /// An Administrator can make a department active or inactive
        /// </summary>
        public bool ActiveDepartmentByIdAndActive(long id, bool active)
        {
            return context.ActiveDepartmentByIdAndActive(id, active);
        }

        /// <summary>
        /// An administrator or doctor can get all departments of one institution
        /// </summary>
        public List<Department> GetAllDepartmentsByInstitutionId(long id)
        {
            return context.GetAllDepartmentsByInstitutionId(id);
        }

        /// <summary>
        /// An Administrator or doctor can get a department by its id
        /// </summary>
        public Department GetDepartmentById(long id)
        {
            return context.GetDepartmentById(id);
        }
    }
}
