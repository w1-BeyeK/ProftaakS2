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
        ICommentContext context = new MemoryCommentContext();
        CommentRepository commentRepository;
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
            Comment comment = new Comment();

            Assert.True(commentRepository.Add(comment, 1));
        }

        [Fact]
        public void GetByTreatment()
        {
            commentRepository = new CommentRepository(context);
            
            Assert.Equal(3, commentRepository.GetByTreatment(1).Count);
        }
    }
}
