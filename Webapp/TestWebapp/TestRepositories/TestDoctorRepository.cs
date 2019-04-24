using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Webapp.Repository;
using Webapp.Context;
using Webapp.Models.Data;
using Webapp.Context.InterfaceContext;
using Webapp.Context.MemoryContext;

namespace TestWebapp.TestRepositories
{
    
    public class TestDoctorRepository : RemoveData
    {
        IDoctorContext context = new MemoryDoctorContext();
        DoctorRepository doctorRepository;

        [Fact]
        public void DoctorRepositoryConstructor()
        {
            EmptyLists();
            doctorRepository = new DoctorRepository(context);

            Assert.NotNull(doctorRepository);
        }

        [Fact]
        public void Add()
        {
            EmptyLists();
            Doctor doctor = new Doctor(0, "een", "een@een.een", "eend");
            doctorRepository = new DoctorRepository(context);
            Assert.Equal(14, doctorRepository.Insert(doctor));
        }

        [Fact]
        public void Update()
        {
            EmptyLists();
            Doctor doctor = new Doctor(12, "een", "een@een.een", "eend");
            doctorRepository = new DoctorRepository(context);
            Assert.True(doctorRepository.Update(doctor));
        }

        [Fact]
        public void GetAll()
        {
            EmptyLists();
            doctorRepository = new DoctorRepository(context);
            Assert.Equal(3, doctorRepository.GetAll().Count);
        }

        //TODO : Need to be implemented soon
        [Fact]
        public void GetByDepartment()
        {
            EmptyLists();
            doctorRepository = new DoctorRepository(context);
            Assert.Equal(2, doctorRepository.GetByDepartment(1).Count);
        }

        //TODO : Need to be implemented soon
        [Fact]
        public void GetByInstitution()
        {
            EmptyLists();
            doctorRepository = new DoctorRepository(context);
            Assert.Equal(3, doctorRepository.GetByInstitution(1).Count);
        }

        [Fact]
        public void GetById()
        {
            EmptyLists();
            doctorRepository = new DoctorRepository(context);
            Assert.Equal("Soof", doctorRepository.GetById(12).UserName);
        }
    }
}
