using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Doctor : UserAccount
    {
        public string Function { get; set; }
        public long EmployeeNumber { get; set; }

        public Doctor(int id, string username, string email) : base(id, username, email)
        {
            Role = "doctor";
        }

        public Doctor(int id, string username, string email, string password) : base(id, username, email, password)
        {
            Role = "doctor";
        }

        public Doctor()
        {
            Role = "doctor";
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
