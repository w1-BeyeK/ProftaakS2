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

        }
    }
}
