using Microsoft.AspNetCore.Identity;
using System;
using Webapp.Models.Data;
using Xunit;

namespace TestWebapp
{
    public class TestTreatment
    {
        [Fact]
        public void TreatmentConstructor()
        {
            string name = "Kaakbehandeling";
            DateTime beginDate = new DateTime(2010-02-10);
            DateTime endDate = new DateTime(2010-03-20);
            Patient patient = new Patient(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female, 23);
            Doctor doctor = new Doctor(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female);
            TreatmentType treatmentType = new TreatmentType("name", "description");
            Treatment treatment = new Treatment(1, name, beginDate, endDate, patient, doctor, treatmentType);

            Assert.Equal(1, treatment.Id);
            Assert.Equal(name, treatment.Name);
            Assert.Equal(beginDate, treatment.BeginDate);
            Assert.Equal(endDate, treatment.EndDate);
        }

        [Fact]
        public void AddComment()
        {
            Patient patient = new Patient(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female, 23);
            Doctor doctor = new Doctor(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female);
            TreatmentType treatmentType = new TreatmentType("name", "description");
            Treatment treatment = new Treatment(1, "name", DateTime.MinValue, DateTime.Today, patient, doctor, treatmentType);
            Comment comment = new Comment("title", "description", DateTime.Today);
            Comment comment2 = new Comment("title", "description", DateTime.Today);

            treatment.AddComment(comment);
            treatment.AddComment(comment2);

            Assert.True(treatment.Comments.Exists(c => c == comment));
            Assert.Equal(2, treatment.Comments.Count);
        }

        [Fact]
        public void TestToString()
        {
            Patient patient = new Patient(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female, 23);
            Doctor doctor = new Doctor(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female);
            TreatmentType treatmentType = new TreatmentType("name", "description");
            Treatment treatment = new Treatment(1, "name", DateTime.MinValue, DateTime.Today, patient, doctor, treatmentType);

            Assert.Equal("Webapp.Models.Data.Treatment", treatment.ToString());
        }

        [Fact]
        public void TestDateTime()
        {
            DateTime day = DateTime.Today;
            TimeSpan span = new TimeSpan(12, 36, 24);

            DateTime jaja = day + span;

            Assert.Equal(new DateTime(), jaja);
        }
    }
}
