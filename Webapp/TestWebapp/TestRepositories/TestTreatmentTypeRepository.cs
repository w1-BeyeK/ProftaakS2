using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Webapp.Repository;
using Webapp.Models.Data;
using Webapp.Context.InterfaceContext;
using Webapp.Context.MemoryContext;
using Webapp.Context;

namespace TestWebapp.TestRepositories
{
    
    public class TestTreatmentTypeRepository : RemoveData
    {
        ITreatmentTypeContext context = new MemoryTreatmentTypeContext();
        TreatmentTypeRepository treatmentTypeRepository;

        [Fact]
        public void TreatmentTypeRepositoryConstructor()
        {
            EmptyLists();
            treatmentTypeRepository = new TreatmentTypeRepository(context);

            Assert.NotNull(treatmentTypeRepository);
        }

        [Fact]
        public void Add()
        {
            EmptyLists();
            TreatmentType treatmentType = new TreatmentType();
            treatmentTypeRepository = new TreatmentTypeRepository(context);
            Assert.Equal(10, treatmentTypeRepository.Insert(treatmentType));
        }

        [Fact]
        public void Update()
        {
            EmptyLists();
            TreatmentType treatmentType = new TreatmentType()
            {
                Id = 9,
                Name = "doedewas"
            };
            treatmentTypeRepository = new TreatmentTypeRepository(context);
            Assert.True(treatmentTypeRepository.Update(treatmentType));
        }

        [Fact]
        public void Delete()
        {
            EmptyLists();
            treatmentTypeRepository = new TreatmentTypeRepository(context);
            Assert.True(treatmentTypeRepository.Delete(9));
        }

        [Fact]
        public void GetAll()
        {
            EmptyLists();
            treatmentTypeRepository = new TreatmentTypeRepository(context);
            Assert.Equal(1, treatmentTypeRepository.GetAll().Count);
        }

        [Fact]
        public void GetById()
        {
            EmptyLists();
            treatmentTypeRepository = new TreatmentTypeRepository(context);
            Assert.Equal("kaas", treatmentTypeRepository.GetById(9).Name);
        }
    }
}
