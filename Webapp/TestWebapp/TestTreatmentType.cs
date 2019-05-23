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
            Department department = new Department(1, "name", "description", true);
            Department department2 = new Department(2, "name", "description", true);
            TreatmentType treatmentType = new TreatmentType("name", "description");

            treatmentType.AddDepartment(department);
            treatmentType.AddDepartment(department2);

            Assert.True(treatmentType.Departments.Exists(d => d == department));
            Assert.Equal(2, treatmentType.Departments.Count);
        }
    }
}
