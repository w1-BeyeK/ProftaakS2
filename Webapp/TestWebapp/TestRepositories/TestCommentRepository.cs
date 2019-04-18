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

    public class TestCommentRepository
    {
        ICommentContext context = new TestMemoryContext();
        CommentRepository commentRepository;

        //[Fact]
        //public void CommentTest()
        //{
        //    TestMemoryContext test = new TestMemoryContext();
        //    ITreatmentContext treatmentContext = test;
        //    ICommentContext commentContext = test;
        //    TreatmentRepository treatmentRepos = new TreatmentRepository(treatmentContext);
        //    CommentRepository commentRepos = new CommentRepository(commentContext);

        //    Doctor doctor = new Doctor(11, null, null, null);
        //    Patient patient = new Patient(15, null, null, null);
        //    TreatmentType treatmentType = new TreatmentType() { Id = 9 };

        //    long id = treatmentRepos.Add(new Treatment(0, "", DateTime.Today, DateTime.Today) { Doctor = doctor, Patient = patient, TreatmentType = treatmentType }, 0, 0, 0);
        //    long commentId = commentContext.Insert(new Comment() { TreatmentId = id, Description = "viandel"});
        //    Treatment treat = treatmentRepos.GetById(id);

        //    Assert.NotNull(treat.Comments.Find(t => t.Id == commentId));
        //    Assert.Equal("viandel", treat.Comments[3].Description);
        //}

        [Fact]
        public void CommentRepositoryConstructor()
        {
            commentRepository = new CommentRepository(context);

            Assert.NotNull(commentRepository);
        }

        [Fact]
        public void Add()
        {
            commentRepository = new CommentRepository(context);
            Comment comment = new Comment()
            {
                TreatmentId = 1
            };

            Assert.Equal(4, commentRepository.Insert(comment).Count);
        }

        //    Assert.Equal(1, commentRepository.Add(comment));
        //}

        [Fact]
        public void GetByTreatment()
        {
            commentRepository = new CommentRepository(context);
            
            Assert.Equal(3, commentRepository.GetByTreatment(1).Count);
        }
    }
}
