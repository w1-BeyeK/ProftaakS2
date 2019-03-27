using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Treatment
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        //TODO : Moet dit in de constructor?
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public TreatmentType TreatmentType { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        public Treatment(int id, string name, DateTime beginDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            BeginDate = beginDate;
            EndDate = endDate;
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
