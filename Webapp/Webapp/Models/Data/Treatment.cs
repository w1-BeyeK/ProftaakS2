using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Treatment : Entity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public TreatmentType TreatmentType { get; set; }
        public List<Comment> Comments { get; set; }

        public Treatment(long id, string name, DateTime beginDate, DateTime endDate)
        {
            Id = (int)id;
            Name = name;
            BeginDate = beginDate;
            EndDate = endDate;

            Comments = new List<Comment>();
        }

        public Treatment(long id, string name, DateTime beginDate, DateTime endDate, Patient patient, Doctor doctor, TreatmentType treatmentType)
        {
            Id = (int)id;
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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
