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
            byte[] logo = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

            Post post = new Post(announcement, logo);
            Assert.Equal(announcement, post.Announcement);
            Assert.Equal(logo, post.Logo);
        }
    }
}
