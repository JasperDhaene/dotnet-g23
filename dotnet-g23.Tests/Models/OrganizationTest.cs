using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class OrganizationTest
    {
        [Fact]
        public void OrganizationHasValidName()
        {
            String name = "foo";
            Organization organization = new Organization(name, "bar");

            Assert.Equal(name, organization.Name);
        }

        [Fact]
        public void OrganizationHasValidLocation()
        {
            String location = "foo";
            Organization organization = new Organization("bar", location);

            Assert.Equal(location, organization.Location);
        }

        [Fact]
        public void OrganizationThrowsExceptionOnEmptyName()
        {
            String name = "";
            Assert.Throws<ArgumentException>(() => new Organization(name, "bar"));
        }

        [Fact]
        public void OrganizationThrowsExceptionOnNoName()
        {
            String name = null;
            Assert.Throws<ArgumentException>(() => new Organization(name, "bar"));
        }

        [Fact]
        public void OrganizationThrowsExceptionOnWhitespaceName()
        {
            String name = " ";
            Assert.Throws<ArgumentException>(() => new Organization(name, "bar"));
        }

        [Fact]
        public void OrganizationThrowsExceptionOnEmptyLocation()
        {
            String location = "";
            Assert.Throws<ArgumentException>(() => new Organization("foo", location));
        }

        [Fact]
        public void OrganizationThrowsExceptionOnNoLocation()
        {
            String location = null;
            Assert.Throws<ArgumentException>(() => new Organization("foo", location));
        }

        [Fact]
        public void OrganizationThrowsExceptionOnWhitespaceLocation()
        {
            String location = " ";
            Assert.Throws<ArgumentException>(() => new Organization("foo", location));
        }

        [Fact]
        public void OrganizationThrowsExceptionOnWhitespaceBothThings() {
            String location = " ";
            String name = " ";
            Assert.Throws<ArgumentException>(() => new Organization(name, location));
        }

        [Fact]
        public void OrganizationThrowsExceptionOnEmptyBothThings() {
            String location = "";
            String name = "";
            Assert.Throws<ArgumentException>(() => new Organization(name, location));
        }

        [Fact]
        public void OrganizationThrowsExceptionOnNullForBothThings() {
            String location = null;
            String name = null;
            Assert.Throws<ArgumentException>(() => new Organization(name, location));
        }
    }
}
