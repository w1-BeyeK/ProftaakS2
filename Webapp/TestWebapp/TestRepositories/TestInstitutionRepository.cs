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
    
    public class TestInstitutionRepository : RemoveData
    {
        IInstitutionContext context = new MemoryInstitutionContext();
        InstitutionRepository institutionRepository;

        [Fact]
        public void InstitutionRepositoryConstructor()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);

            Assert.NotNull(institutionRepository);
        }

        [Fact]
        public void InstitutionRepositoryConstructorFalseInput()
        {
            EmptyLists();
            
            Exception ex = Assert.Throws<NullReferenceException>(() => institutionRepository = new InstitutionRepository(null));
            Assert.Equal("De instellingContext is leeg.", ex.Message);
        }

        [Fact]
        public void AddInstitution()
        {
            EmptyLists();
            Administrator admin = new Administrator();
            Institution institution = new Institution("een", 1, "eend", "696969", "Lichtenstein", admin);
            institutionRepository = new InstitutionRepository(context);
            Assert.Equal(3, institutionRepository.Insert(institution));
        }

        [Fact]
        public void AddFalseInput()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => institutionRepository.Insert(null));
            Assert.Equal("De instelling is leeg.", ex.Message);
        }

        [Fact]
        public void Update()
        {
            EmptyLists();
            Administrator admin = new Administrator();
            Institution institution = new Institution("een", 1, "eend", "696969", "Lichtenstein", admin)
            {
                Id = 1
            };
            institutionRepository = new InstitutionRepository(context);
            Assert.True(institutionRepository.Update(institution));
        }

        [Fact]
        public void UpdateFalseInput()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => institutionRepository.Update(null));
            Assert.Equal("De instelling is leeg.", ex.Message);
        }

        [Fact]
        public void GetAll()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);
            Assert.Equal(2, institutionRepository.GetAll().Count);
        }

        [Fact]
        public void AddDepartmentToInstitution()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);
            Assert.True(institutionRepository.AddDepartmentToInstitution(1, 1));
        }

        [Fact]
        public void AddDepartmentToInstitutionFalseInstitutionId()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => institutionRepository.AddDepartmentToInstitution(-1, 1));
            Assert.Equal("Het instellingId is leeg.", ex.Message);
        }

        [Fact]
        public void AddDepartmentToInstitutionFalseDepartmentId()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => institutionRepository.AddDepartmentToInstitution(1, -1));
            Assert.Equal("Het afdelingId is leeg.", ex.Message);
        }

        [Fact]
        public void GetById()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);
            Assert.Equal("instituut", institutionRepository.GetById(1).Name);
        }

        [Fact]
        public void GetByIdFalseInput()
        {
            EmptyLists();
            institutionRepository = new InstitutionRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => institutionRepository.GetById(-1));
            Assert.Equal("Het instellingId is leeg.", ex.Message);
        }
    }
}
