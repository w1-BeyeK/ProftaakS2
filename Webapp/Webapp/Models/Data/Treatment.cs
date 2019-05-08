using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Treatment : Entity
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Patient Patient { get; set; }
        public long PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public TreatmentType TreatmentType { get; set; }
        public long TreatmentTypeId { get; set; }
        public List<Comment> Comments { get; set; }

        public Treatment(long id, string name, DateTime beginDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            BeginDate = beginDate;
            EndDate = endDate;

            Comments = new List<Comment>();
        }

        public Treatment(long id, string name, DateTime beginDate, DateTime endDate, Patient patient, Doctor doctor, TreatmentType treatmentType)
        {
            Id = id;
            Name = name;
            BeginDate = beginDate;
            EndDate = endDate;
            Patient = patient;
            Doctor = doctor;
            TreatmentType = treatmentType;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public Treatment()
        {

        }

        public int DaysUntilTreatment()
        {
            throw new NotImplementedException();
        }

        public int GetAge()
        {
            int age = DateTime.Now.Day - EndDate.Day;
            return age;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
