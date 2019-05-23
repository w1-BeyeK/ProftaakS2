using System;
using System.Collections.Generic;
using System.Security.Authentication;
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

    public class TestDepartmentRepository : RemoveData
    {
        IDepartmentContext context = new MemoryDepartmentContext();
        DepartmentRepository departmentRepository;

        [Fact]
        public void DepartmentRepositoryConstructor()
        {
            EmptyLists();
            departmentRepository = new DepartmentRepository(context);

            Assert.NotNull(departmentRepository);
        }

        [Fact]
        public void DepartmentRepositoryConstructorFalseInput()
        {
            EmptyLists();
            IDepartmentContext testContext = null;

            Exception ex = Assert.Throws<NullReferenceException>(() => departmentRepository = new DepartmentRepository(testContext));
            Assert.Equal("De afdelingContext is leeg.", ex.Message);
        }

        [Fact]
        public void Add()
        {
            EmptyLists();
            departmentRepository = new DepartmentRepository(context);
            Department department = new Department(3, "naam", "beschrijving", true);

            Assert.Equal(3, departmentRepository.Insert(department));
        }

        [Fact]
        public void AddFalseInput()
        {
            EmptyLists();
            departmentRepository = new DepartmentRepository(context);

            Exception ex = Assert.Throws<NullReferenceException>(() => departmentRepository.Insert(null));
            Assert.Equal("De afdeling is leeg.", ex.Message);
        }

        [Fact]
        public void Delete()
        {
            EmptyLists();
            departmentRepository = new DepartmentRepository(context);

            Assert.True(departmentRepository.Delete(1));
        }

        [Fact]
        public void DeleteFalseInput()
        {
            EmptyLists();
            departmentRepository = new DepartmentRepository(context);

            Exception ex = Assert.Throws<NullReferenceException>(() => departmentRepository.Delete(-1));
            Assert.Equal("Het afdelingId is leeg.", ex.Message);
        }

        
        [Fact]
        public void GetAll()
        {
            EmptyLists();
            departmentRepository = new DepartmentRepository(context);
            Assert.Equal(3, departmentRepository.GetAll().Count);
        }


        [Fact]
        public void GetById()
        {
            EmptyLists();
            departmentRepository = new DepartmentRepository(context);

            Assert.Equal("afdeling 1", departmentRepository.GetById(1).Name);
        }

        [Fact]
        public void GetByIdFalseInput()
        {
            EmptyLists();
            departmentRepository = new DepartmentRepository(context);

            Exception ex = Assert.Throws<NullReferenceException>(() => departmentRepository.GetById(-1));
            Assert.Equal("Het afdelingId is leeg.", ex.Message);
        }

        [Fact]
        public void Update()
        {
            EmptyLists();
            departmentRepository = new DepartmentRepository(context);
            Department department = new Department(1, "naam", "beschrijving", true);

            Assert.True(departmentRepository.Update(department));
        }

        [Fact]
        public void UpdateFalseInput()
        {
            EmptyLists();
            departmentRepository = new DepartmentRepository(context);

            Exception ex = Assert.Throws<NullReferenceException>(() => departmentRepository.Update(null));
            Assert.Equal("De afdeling is leeg.", ex.Message);
        }
    }



}
