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

    public class TestTreatmentRepository : RemoveData
    {
        ITreatmentContext context = new MemoryTreatmentContext();
        TreatmentRepository treatmentRepository;

        [Fact]
        public void TreatmentRepositoryConstructor()
        {
            EmptyLists();
            treatmentRepository = new TreatmentRepository(context);

            Assert.NotNull(treatmentRepository);
        }

        [Fact]
        public void TreatmentRepositoryConstructorFalseInput()
        {
            EmptyLists();

            Exception ex = Assert.Throws<NullReferenceException>(() => treatmentRepository = new TreatmentRepository(null));
            Assert.Equal("De behandelingContext is leeg.", ex.Message);
        }

        [Fact]
        public void Add()
        {
            EmptyLists();
            Treatment treatment = new Treatment(1, "een", DateTime.Today, DateTime.Today);
            treatmentRepository = new TreatmentRepository(context);
            Assert.Equal(4, treatmentRepository.Insert(treatment));
        }

        [Fact]
        public void AddFalseInput()
        {
            EmptyLists();
            treatmentRepository = new TreatmentRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => treatmentRepository.Insert(null));
            Assert.Equal("De behandeling is leeg.", ex.Message);
        }

        [Fact]
        public void Update()
        {
            EmptyLists();
            Treatment treatment = new Treatment(1, "een", DateTime.Today, DateTime.Today);
            treatmentRepository = new TreatmentRepository(context);
            Assert.True(treatmentRepository.Update(treatment));
        }

        [Fact]
        public void UpdateFalseInput()
        {
            EmptyLists();
            treatmentRepository = new TreatmentRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => treatmentRepository.Update(null));
            Assert.Equal("De behandeling is leeg.", ex.Message);
        }

        [Fact]
        public void GetByDoctor()
        {
            EmptyLists();
            treatmentRepository = new TreatmentRepository(context);
            Assert.Equal(3, treatmentRepository.GetByDoctor(11).Count);
        }

        [Fact]
        public void GetByDoctorFalseInput()
        {
            EmptyLists();
            treatmentRepository = new TreatmentRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => treatmentRepository.GetByDoctor(-1));
            Assert.Equal("Het dokterId is leeg.", ex.Message);
        }

        [Fact]
        public void GetByPatient()
        {
            EmptyLists();
            treatmentRepository = new TreatmentRepository(context);
            Assert.Equal(4, treatmentRepository.GetByPatient(12).Count);
        }

        [Fact]
        public void GetByPatientFalseInput()
        {
            EmptyLists();
            treatmentRepository = new TreatmentRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => treatmentRepository.GetByPatient(-1));
            Assert.Equal("Het patiëntId is leeg.", ex.Message);
        }
        
        [Fact]
        public void GetById()
        {
            EmptyLists();
            treatmentRepository = new TreatmentRepository(context);
            Assert.Equal("Arm amputeren", treatmentRepository.GetById(1).Name);
        }

        [Fact]
        public void GetByIdFalseInput()
        {
            EmptyLists();
            treatmentRepository = new TreatmentRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => treatmentRepository.GetById(-1));
            Assert.Equal("Het behandelingId is leeg.", ex.Message);
        }

        [Fact]
        public void CheckTreatmentRelationship()
        {
            EmptyLists();
            treatmentRepository = new TreatmentRepository(context);
            Assert.True(treatmentRepository.CheckTreatmentRelationship(11, 12));
        }

        [Fact]
        public void CheckTreatmentRelationshipFalseDoctorId()
        {
            EmptyLists();
            treatmentRepository = new TreatmentRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => treatmentRepository.CheckTreatmentRelationship(-1, 1));
            Assert.Equal("Het dokterId is leeg.", ex.Message);
        }

        [Fact]
        public void CheckTreatmentRelationshipFalsePatientId()
        {
            EmptyLists();
            treatmentRepository = new TreatmentRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => treatmentRepository.CheckTreatmentRelationship(1, -1));
            Assert.Equal("Het patiëntId is leeg.", ex.Message);
        }
    }
}
