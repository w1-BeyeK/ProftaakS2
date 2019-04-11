using System;
using System.Collections.Generic;
using System.Text;
using Webapp.Context;
using Webapp.Interfaces;
using Webapp.Models.Data;
using Webapp.Repository;
using Xunit;

namespace TestWebapp.TestRepositories
{

    public class TestDepartmentRepository
    {
        IDepartmentContext context = new DepartmentTestContext();
        DepartmentRepository departmentRepository;
        [Fact]
        public void DepartmentRepositoryConstructor()
        {
            departmentRepository = new DepartmentRepository(context);

            Assert.NotNull(departmentRepository);
        }

        [Fact]
        public void Add()
        {
            departmentRepository = new DepartmentRepository(context);
            Department comment = new Department(1, "naam", "beschrijving", true);

            Assert.Equal(1, departmentRepository.Add(comment));
        }

        [Fact]
        public void GetById()
        {
            departmentRepository = new DepartmentRepository(context);
            
            Assert.Equal("naam", departmentRepository.GetById(1).Name);
        }
    }
}
