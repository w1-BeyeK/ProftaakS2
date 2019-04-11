using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Webapp.Repository;
using Webapp.Context;
using Webapp.Models.Data;

namespace TestWebapp.TestRepositories
{
    
    public class TestTreatmentTypeRepository
    {
        ITreatmentTypeContext context = new TreatmentTypeTestContext();
        TreatmentTypeRepository treatmentTypeRepository;

        [Fact]
        public void TreatmentTypeRepositoryConstructor()
        {
            treatmentTypeRepository = new TreatmentTypeRepository(context);

            Assert.NotNull(treatmentTypeRepository);
        }

        [Fact]
        public void Add()
        {
            TreatmentType treatmentType = new TreatmentType();
            treatmentTypeRepository = new TreatmentTypeRepository(context);
            Assert.Equal(1, treatmentTypeRepository.Add(treatmentType));
        }

        [Fact]
        public void Update()
        {
            TreatmentType treatmentType = new TreatmentType();
            treatmentTypeRepository = new TreatmentTypeRepository(context);
            Assert.True(treatmentTypeRepository.Update(treatmentType));
        }

        [Fact]
        public void Delete()
        {
            treatmentTypeRepository = new TreatmentTypeRepository(context);
            Assert.True(treatmentTypeRepository.Delete(1));
        }

        [Fact]
        public void GetAll()
        {
            treatmentTypeRepository = new TreatmentTypeRepository(context);
            Assert.Equal(2, treatmentTypeRepository.GetAll().Count);
        }

        [Fact]
        public void GetById()
        {
            treatmentTypeRepository = new TreatmentTypeRepository(context);
            Assert.Equal("treatmentType", treatmentTypeRepository.GetById(1).Name);
        }
    }
}
