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

    public class TestPatientRepository
    {
        IPatientContext context = new MemoryPatientContext();
        PatientRepository patientRepository;

        [Fact]
        public void PatientRepositoryConstructor()
        {
            patientRepository = new PatientRepository(context);

            Assert.NotNull(patientRepository);
        }

        [Fact]
        public void Add()
        {
            patientRepository = new PatientRepository(context);

            Patient patient = new Patient();

            Assert.Equal(1, patientRepository.Add(patient));
        }

        [Fact]
        public void GetAll()
        {
            patientRepository = new PatientRepository(context);

            Assert.Equal(3, patientRepository.GetAll().Count);
        }

        [Fact]
        public void GetById()
        {
            patientRepository = new PatientRepository(context);


            Assert.Equal("naam", patientRepository.GetById(1).Name);
        }

        [Fact]
        public void Update()
        {
            patientRepository = new PatientRepository(context);

            Patient patient = new Patient(1, "naam", "beschrijving", "naam");

            Assert.True(patientRepository.Update(patient));
        }
    }
}
