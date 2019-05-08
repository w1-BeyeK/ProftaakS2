using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
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

    public class TestCommentRepository : RemoveData
    {
        ICommentContext context = new MemoryCommentContext();
        CommentRepository commentRepository;

        [Fact]
        public void CommentRepositoryConstructor()
        {
            EmptyLists();
            commentRepository = new CommentRepository(context);

            Assert.NotNull(commentRepository);
        }

        [Fact]
        public void CommentRepositoryConstructorFalseinput()
        {
            EmptyLists();
            ICommentContext testContext = null;
            Exception ex = Assert.Throws<NullReferenceException>(() => commentRepository = new CommentRepository(testContext));
            Assert.Equal("Het commentaarContext is leeg.", ex.Message);
        }

        [Fact]
        public void Insert()
        {
            EmptyLists();
            commentRepository = new CommentRepository(context);

            Comment comment = new Comment()
            {
                TreatmentId = 1,
            };

            Assert.Equal(4, commentRepository.Insert(comment).Count);
        }

        [Fact]
        public void InsertFalseInput()
        {
            commentRepository = new CommentRepository(context);
            Exception ex = Assert.Throws<NullReferenceException>(() => commentRepository.Insert(null));
            Assert.Equal("Het commentaar is leeg.", ex.Message);
        }

        [Fact]
        public void GetByTreatment()
        {
            EmptyLists();
            commentRepository = new CommentRepository(context);
            
            Assert.Equal(3, commentRepository.GetByTreatment(1).Count);
        }

        [Fact]
        public void GetByTreatmentFalseInput()
        {
            EmptyLists();
            commentRepository = new CommentRepository(context);

            Exception ex = Assert.Throws<NullReferenceException>(() => commentRepository.GetByTreatment(-1));
            Assert.Equal("De behandelingId is leeg.", ex.Message);

            Assert.Equal(3, commentRepository.GetByTreatment(1).Count);
        }
    }
}
