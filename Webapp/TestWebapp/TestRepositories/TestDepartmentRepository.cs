using System;
using System.Collections.Generic;
using System.Text;
using Webapp.Context;
using Webapp.Context.InterfaceContext;
using Webapp.Context.MemoryContext;
using Webapp.Interfaces;
using Webapp.Models.Data;
using Webapp.Repository;
using Xunit;

namespace TestWebapp.TestRepositories
{

    public class TestDepartmentRepository
    {
        IDepartmentContext context = new TestMemoryContext();
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
            Department department = new Department(3, "naam", "beschrijving", true);

            Assert.Equal(3, departmentRepository.Add(department));
        }

        [Fact]
        public void Delete()
        {
            departmentRepository = new DepartmentRepository(context);

            Assert.True(departmentRepository.Delete(1));
        }

        //TODO : Need to be discussed
        [Fact]
        public void GetAll()
        {
            departmentRepository = new DepartmentRepository(context);
            Assert.Equal(3, departmentRepository.GetAll().Count);
        }

        //TODO : Need to be discussed
        [Fact]
        public void GetById()
        {
            departmentRepository = new DepartmentRepository(context);

            Assert.Equal("Soepderpoep", departmentRepository.GetById(1).Name);
        }

        [Fact]
        public void Update()
        {
            departmentRepository = new DepartmentRepository(context);
            Department department = new Department(1, "naam", "beschrijving", true);

            Assert.True(departmentRepository.Update(department));
        }
    }



}
