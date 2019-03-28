using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Models.Data
{
    public class Comment : Entity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Treatment Treatment { get; set; }

        public Comment(string title, string description, DateTime date, Treatment treatment)
        {
            Title = title;
            Description = description;
            Date = date;
            Treatment = treatment;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
