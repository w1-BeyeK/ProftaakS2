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
        public void DoctorRepositoryConstructorFalseInput()
        {
            EmptyLists();
            Exception ex = Assert.Throws<NullReferenceException>(() => doctorRepository = new DoctorRepository(null));
            Assert.Equal("De dokterContext is leeg.", ex.Message);
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
        public void AddFalseInput()
        {
            EmptyLists();
            doctorRepository = new DoctorRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => doctorRepository.Insert(null));
            Assert.Equal("De dokter is leeg.", ex.Message);
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
        public void UpdateFalseInput()
        {
            EmptyLists();
            doctorRepository = new DoctorRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => doctorRepository.Update(null));
            Assert.Equal("De dokter is leeg.", ex.Message);
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
            Assert.Equal(2, doctorRepository.GetByDoctorWithDepartment(1).Count);
        }

        [Fact]
        public void GetByDepartmentFalseInput()
        {
            EmptyLists();
            doctorRepository = new DoctorRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => doctorRepository.GetByDoctorWithDepartment(-1));
            Assert.Equal("Het afdelingId is leeg.", ex.Message);
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
        public void GetByInstitutionFalseInput()
        {
            EmptyLists();
            doctorRepository = new DoctorRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => doctorRepository.GetByInstitution(-1));
            Assert.Equal("Het instellingId is leeg.", ex.Message);
        }

        [Fact]
        public void GetById()
        {
            EmptyLists();
            doctorRepository = new DoctorRepository(context);
            Assert.Equal("SOOF", doctorRepository.GetById(12).UserName);
        }

        [Fact]
        public void GetByIdFalseInput()
        {
            EmptyLists();
            doctorRepository = new DoctorRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => doctorRepository.GetById(-1));
            Assert.Equal("Het dokterId is leeg.", ex.Message);
        }
    }
}
