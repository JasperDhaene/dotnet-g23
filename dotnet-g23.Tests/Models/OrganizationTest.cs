//using dotnet_g23.Models.Domain;
//using System;
//using Xunit;

//namespace dotnet_g23.Tests.Models
//{
//    public class OrganizationTest
//    {
//        [Fact]
//        public void OrganizationConstructorShouldCreateNewOrganization()
//        {
//            string _name = "Organization";
//            string _location = "Gent";
//            Organization organization = new Organization(_name, _location);
//            Assert.Equal(_name, organization.Name);
//            Assert.Equal(_location, organization.Location);
//        }

//        [Fact]
//        public void ConstructorShouldNotCreateNewOrganizationBecauseNameIsNull()
//        {
//            Assert.Throws<ArgumentException>(() => new Organization(null, "Ieper"));
//        }

//        [Fact]
//        public void ConstructorShouldNotCreateNewOrganizationBecauseNameIsEmpty()
//        {
//            Assert.Throws<ArgumentException>(() => new Organization("", "Ieper"));
//        }

//        [Fact]
//        public void ConstructorShouldNotCreateNewOrganizationBecauseNameIsSpaces()
//        {
//            Assert.Throws<ArgumentException>(() => new Organization("            ", "Ieper"));
//        }

//        [Fact]
//        public void ConstructorShouldNotCreateNewOrganizationBecauseLocationIsSpaces()
//        {
//            Assert.Throws<ArgumentException>(() => new Organization("Organization", "          "));
//        }

//        [Fact]
//        public void ConstructorShouldNotCreateNewOrganizationBecauseLocationIsEmpty()
//        {
//            Assert.Throws<ArgumentException>(() => new Organization("Organization", ""));
//        }

//        [Fact]
//        public void ConstructorShouldNotCreateNewOrganizationBecauseLocationIsNull()
//        {
//            Assert.Throws<ArgumentException>(() => new Organization(null, null));
//        }

//        [Fact]
//        public void ConstructorShouldNotCreateNewOrganizationBecauseBothArgumentsAreSpaces()
//        {
//            Assert.Throws<ArgumentException>(() => new Organization("           ", "          "));
//        }

//        [Fact]
//        public void ConstructorShouldNotCreateNewOrganizationBecauseBothArgumentsAreEmpty()
//        {
//            Assert.Throws<ArgumentException>(() => new Organization("", ""));
//        }

//        [Fact]
//        public void ConstructorShouldNotCreateNewOrganizationBecauseBothArgumentsAreNull()
//        {
//            Assert.Throws<ArgumentException>(() => new Organization(null, null));
//        }
//    }
//}
