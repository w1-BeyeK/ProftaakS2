using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Webapp.Repository;
using Webapp.Context;
using Webapp.Models.Data;

namespace TestWebapp.TestRepositories
{
    
    public class TestDoctorRepository
    {
        IDoctorContext context = new DoctorTestContext();
        DoctorRepository doctorRepository;

        [Fact]
        public void DoctorRepositoryConstructor()
        {
            doctorRepository = new DoctorRepository(context);

            Assert.NotNull(doctorRepository);
        }

        [Fact]
        public void Add()
        {
            Doctor doctor = new Doctor(1, "een", "een@een.een", "eend");
            doctorRepository = new DoctorRepository(context);
            Assert.Equal(1, doctorRepository.Add(doctor));
        }

        [Fact]
        public void Update()
        {
            Doctor doctor = new Doctor(1, "een", "een@een.een", "eend");
            doctorRepository = new DoctorRepository(context);
            Assert.True(doctorRepository.Update(doctor));
        }

        [Fact]
        public void GetAll()
        {
            doctorRepository = new DoctorRepository(context);
            Assert.Equal(2, doctorRepository.GetAll().Count);
        }

        [Fact]
        public void GetByDepartment()
        {
            doctorRepository = new DoctorRepository(context);
            Assert.Equal(2, doctorRepository.GetByDepartment(1).Count);
        }

        [Fact]
        public void GetByInstitution()
        {
            doctorRepository = new DoctorRepository(context);
            Assert.Equal(2, doctorRepository.GetByInstitution(1).Count);
        }

        [Fact]
        public void GetById()
        {
            doctorRepository = new DoctorRepository(context);
            Assert.Equal("doctor", doctorRepository.GetById(1).UserName);
        }
    }
}
