using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Administrator : BaseAccount
    {
        public long EmployeeNumber { get; set; }

        public Administrator(int id, string username, string email) : base(id, username, email)
        {
            Role = "admin";
        }

        public Administrator(int id, string username, string email, string password) : base(id, username, email, password)
        {
            Role = "admin";
        }

        public Administrator()
        {
            Role = "admin";
        }

        public void AddDepartment()
        {

        }

        public void AddDoctor()
        {

        }

        public void AddTreatmentType()
        {

        }

        public void EditDepartment()
        {

        }

        public void EditDoctor()
        {

        }

        public void EditTreatmentType()
        {

        }

        public void ActivateDepartment()
        {
            
        }

        public void ActivateDoctor()
        {

        }

        public void ActivateTreatmentType()
        {

        }

        public void ShowDepartments()
        {

        }

        public void ShowDoctors()
        {

        }

        public void ShowctivateTreatmentTypes()
        {

        }
    }
}
