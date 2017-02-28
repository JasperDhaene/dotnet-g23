using dotnet_g23.Models.Domain;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class GroupTest
    {
        [Fact]
        public void GroupHasValidName()
        {
            String name = "foobar";
            Group group = new Group(name);

            Assert.Equal(name, group.Name);
        }

        [Fact]
        public void GroupThrowsExceptionOnEmptyName()
        {
            String name = "";

            Assert.Throws<ArgumentException>(() => new Group(name));
        }

        [Fact]
        public void GroupThrowsExceptionOnNoName()
        {
            String name = null;

            Assert.Throws<ArgumentException>(() => new Group(name));
        }

        [Fact]
        public void GroupThrowsExceptionOnWhitespaceName()
        {
            String name = " ";

            Assert.Throws<ArgumentException>(() => new Group(name));
        }

        [Fact]
        public void GroupIsClosedByDefault()
        {
            Group group = new Group("foobar");

            Assert.True(group.Closed);
        }

        [Fact]
        public void GroupIsOpenWhenSpecified()
        {
            Group group = new Group("foobar", false);

            Assert.False(group.Closed);
        }
    }
}