using Microsoft.AspNetCore.Identity;
using System;
using Webapp.Models.Data;
using Xunit;

namespace TestWebapp
{
    public class TestComment
    {
        [Fact]
        public void CommentConstructor()
        {
            string title = "De zaag is nodig";
            string description = "Zaag de linkervoet eraf vanwege hevige infectie";
            DateTime date = new DateTime(2010-02-03);
            Patient patient = new Patient(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female, 23);
            Doctor doctor = new Doctor(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female);
            TreatmentType treatmentType = new TreatmentType("name", "description");
            Treatment treatment = new Treatment("name", date, date, patient, doctor, treatmentType);

            Comment comment = new Comment(title, description, date, treatment);

            Assert.Equal(title, comment.Title);
            Assert.Equal(description, comment.Description);
            Assert.Equal(date, comment.Date);
            Assert.Equal(treatment, comment.Treatment);
        }
    }
}
