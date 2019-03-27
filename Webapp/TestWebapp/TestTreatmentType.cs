using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Webapp.Models.Data;
using Xunit;

namespace TestWebapp
{
    public class TestTreatmentType
    {
        [Fact]
        public void TreatmentTypeConstructor()
        {
            
            string name = "Tnad trekken";
            string description = "tand uithalen";
            TreatmentType treatmentType = new TreatmentType(name, description);

            Assert.Equal(name, treatmentType.Name);
            Assert.Equal(description, treatmentType.Description);
        }
        
        [Fact]
        public void AddDepartment()
        {
            Department department = new Department("name", "description", true);
            Department department2 = new Department("name", "description", true);
            TreatmentType treatmentType = new TreatmentType("name", "description");

            treatmentType.AddDepartment(department);
            treatmentType.AddDepartment(department2);

            Assert.True(treatmentType.Departments.Exists(d => d == department));
            Assert.Equal(2, treatmentType.Departments.Count);
        }

        [Fact]
        public void AddDoctor()
        {
            Doctor doctor = new Doctor(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female);
            Doctor doctor2 = new Doctor(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female);
            TreatmentType treatmentType = new TreatmentType("name", "description");

            treatmentType.AddDoctor(doctor);
            treatmentType.AddDoctor(doctor2);

            Assert.True(treatmentType.Doctors.Exists(d => d == doctor));
            Assert.Equal(2, treatmentType.Doctors.Count);
        }

        [Fact]
        public void AddTreatment()
        {
            Patient patient = new Patient(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female, 23);
            Doctor doctor = new Doctor(1, "username", "email", "password", "name", DateTime.Today, "phonenumber", true, Gender.Female);
            TreatmentType treatmentType = new TreatmentType("name", "description");
            Treatment treatment = new Treatment("name", DateTime.MinValue, DateTime.Today, patient, doctor, treatmentType);
            Treatment treatment2 = new Treatment("name", DateTime.MinValue, DateTime.Today, patient, doctor, treatmentType);

            treatmentType.AddTreatment(treatment);
            treatmentType.AddTreatment(treatment2);

            Assert.True(treatmentType.Treatments.Exists(t => t == treatment));
            Assert.Equal(2, treatmentType.Treatments.Count);
        }
    }
}
