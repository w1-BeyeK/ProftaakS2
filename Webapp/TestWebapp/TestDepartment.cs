using Microsoft.AspNetCore.Identity;
using System;
using Webapp.Models.Data;
using Xunit;

namespace TestWebapp
{
    public class TestDepartment
    {
        [Fact]
        public void DepartmentConstructor()
        {
            string name = "Mondheelkunde";
            bool active = true;
            string description = "De afdeling van mondheelkunde";

            Department department = new Department(name, active, description);

            Assert.Equal(name, department.Name);
            Assert.Equal(active, department.Active);
            Assert.Equal(description, department.Description);
        }
    }
}
