using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Doctor : UserAccount
    {

        public long EmployeeNumber { get; set; }

        public string Function { get; set; }

        public Doctor()
        {

        }

        public void RegisterTreatment()
        {

        }

        public void ChangeContactPreference()
        {

        }

        public void ShowDoctors()
        {

        }

        public void ShowPatients()
        {

        }

        public void ShowTreatmentsTypes()
        {

        }

        public override void AddComment()
        {
            base.AddComment();
        }

        public override void ChangePersonalData()
        {
            base.ChangePersonalData();
        }

        public override void ShowTreatments()
        {
            base.ShowTreatments();
        }
    }
}
