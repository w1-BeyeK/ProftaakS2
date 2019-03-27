using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Treatment
    {
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public TreatmentType TreatmentType { get; set; }
        public List<Comment> Comments { get; set; }

        public Treatment(string name, DateTime beginDate, DateTime endDate, Patient patient, Doctor doctor, TreatmentType treatmentType)
        {
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

        public int DaysUntilTreatment()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
