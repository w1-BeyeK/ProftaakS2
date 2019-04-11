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
            Comment comment = new Comment();

            Assert.True(departmentRepository.Add(comment, 1));
        }

        [Fact]
        public void GetByTreatment()
        {
            departmentRepository = new DepartmentRepository(context);
            
            Assert.Equal(3, departmentRepository.GetByTreatment(1).Count);
        }
    }
}
