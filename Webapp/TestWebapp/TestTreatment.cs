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
            Patient patient = new Patient(1, "username", "email", "password");
            Doctor doctor = new Doctor(1, "username", "password");
            TreatmentType treatmentType = new TreatmentType("name", "description");
            Treatment treatment = new Treatment(name, beginDate, endDate, patient, doctor, treatmentType);

            Assert.Equal(name, treatment.Name);
            Assert.Equal(beginDate, treatment.BeginDate);
            Assert.Equal(endDate, treatment.EndDate);
        }
    }
}
