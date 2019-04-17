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
    
    public class TestInstitutionRepository
    {
        IInstitutionContext context = new TestMemoryContext();
        InstitutionRepository institutionRepository;

        [Fact]
        public void InstitutionRepositoryConstructor()
        {
            institutionRepository = new InstitutionRepository(context);

            Assert.NotNull(institutionRepository);
        }

        [Fact]
        public void AddInstitution()
        {
            Administrator admin = new Administrator();
            Institution institution = new Institution("een", 1, "eend", "696969", "Lichtenstein", admin);
            institutionRepository = new InstitutionRepository(context);
            Assert.Equal(3, institutionRepository.AddInstitution(institution));
        }

        [Fact]
        public void Update()
        {
            Administrator admin = new Administrator();
            Institution institution = new Institution("een", 1, "eend", "696969", "Lichtenstein", admin)
            {
                Id = 1
            };
            institutionRepository = new InstitutionRepository(context);
            Assert.True(institutionRepository.Update(institution));
        }

        [Fact]
        public void GetAll()
        {
            institutionRepository = new InstitutionRepository(context);
            Assert.Equal(2, institutionRepository.GetAll().Count);
        }

        [Fact]
        public void AddDepartmentToInstitution()
        {
            institutionRepository = new InstitutionRepository(context);
            Assert.True(institutionRepository.AddDepartmentToInstitution(1, 1));
        }

        [Fact]
        public void GetById()
        {
            institutionRepository = new InstitutionRepository(context);
            Assert.Equal("instituut", institutionRepository.GetById(1).Name);
        }
    }
}
