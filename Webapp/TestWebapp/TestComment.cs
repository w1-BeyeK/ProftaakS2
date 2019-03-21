using Microsoft.AspNetCore.Identity;
using System;
using Webapp.Models.Data;
using Xunit;

namespace TestWebapp
{
    public class TestComment
    {
        [Fact]
        public void CommentConstructor()
        {
            string title = "De zaag is nodig";
            string description = "Zaag de linkervoet eraf vanwege hevige infectie";
            DateTime date = new DateTime(2010-02-03);

            Comment comment = new Comment(title, description, date);

            Assert.Equal(title, comment.Title);
            Assert.Equal(description, comment.Description);
            Assert.Equal(date, comment.Date);
        }
    }
}
