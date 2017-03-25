using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class PostTest
    {
        [Fact]
        public void ConstructorShouldCreateNewPost() {
            String announcement = "Foobar";

            Post post = new Post(announcement);
            Assert.Equal(announcement, post.Announcement);
        }
    }
}
