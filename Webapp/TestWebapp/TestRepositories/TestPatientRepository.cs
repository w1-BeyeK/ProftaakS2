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

    public class TestPatientRepository : RemoveData
    {
        IPatientContext context = new MemoryPatientContext();
        PatientRepository patientRepository;

        [Fact]
        public void PatientRepositoryConstructor()
        {
            EmptyLists();
            patientRepository = new PatientRepository(context);

            Assert.NotNull(patientRepository);
        }

        [Fact]
        public void PatientRepositoryConstructorFalseInput()
        {
            EmptyLists();

            Exception ex = Assert.Throws<NullReferenceException>(() => patientRepository = new PatientRepository(null));
            Assert.Equal("De patiëntContext is leeg.", ex.Message);
        }

        [Fact]
        public void Add()
        {
            EmptyLists();
            patientRepository = new PatientRepository(context);

            Patient patient = new Patient();

            Assert.Equal(16, patientRepository.Insert(patient));
        }

        [Fact]
        public void AddFalseInput()
        {
            EmptyLists();
            patientRepository = new PatientRepository(context);

            Patient patient = new Patient();

            Exception ex = Assert.Throws<NullReferenceException>(() => patientRepository.Insert(null));
            Assert.Equal("De patiënt is leeg.", ex.Message);
        }

        [Fact]
        public void GetAll()
        {
            EmptyLists();
            patientRepository = new PatientRepository(context);

            Assert.Equal(5, patientRepository.GetAll().Count);
        }

        [Fact]
        public void GetById()
        {
            EmptyLists();
            patientRepository = new PatientRepository(context);

            Assert.Equal("Stijn Driedubbels", patientRepository.GetById(15).Name);
        }

        [Fact]
        public void GetByIdFalseInput()
        {
            EmptyLists();
            patientRepository = new PatientRepository(context);

            Exception ex = Assert.Throws<NullReferenceException>(() => patientRepository.GetById(-1));
            Assert.Equal("De patiëntId is leeg.", ex.Message);
        }

        [Fact]
        public void Update()
        {
            EmptyLists();
            patientRepository = new PatientRepository(context);

            Patient patient = new Patient(15, "naam", "beschrijving", "naam");

            Assert.True(patientRepository.Update(patient));
        }

        [Fact]
        public void UpdateFalseInput()
        {
            EmptyLists();
            patientRepository = new PatientRepository(context);

            Exception ex = Assert.Throws<NullReferenceException>(() => patientRepository.Update(null));
            Assert.Equal("De patiënt is leeg.", ex.Message);
        }
    }
}
