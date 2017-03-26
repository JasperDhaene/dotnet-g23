using dotnet_g23.Models.Domain;
using System;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class OrganizationTest
    {

        [Fact]
        public void ContructorWithParametersOfOrganizationShouldOrganization() {
            Organization org = new Organization("Foo", "Bar", "foo.bar");
            Assert.Equal("Foo", org.Name);
            Assert.Equal("Bar", org.Location);
            Assert.Equal("foo.bar", org.Domain);
        }

        [Fact]
        public void NewOrganizationShouldHaveEmptyListsOfParticipantsAndGroups() {
            Organization org = new Organization("Foo", "Bar", "foo.bar");
            Assert.Empty(org.Participants);
            Assert.Empty(org.Groups);
        }

        [Fact]
        public void ContructorOfOrganizationShouldThowExceptionBecauseWrongName() {
            String loc = "Bar";
            String dom = "foo.bar";
            Assert.Throws<GoedBezigException>(() => new Organization("", loc, dom));
        }

        [Fact]
        public void ContructorOfOrganizationShouldThowExceptionBecauseWrongLocation() {
            String nam = "foo";
            String dom = "foo.bar";
            Assert.Throws<GoedBezigException>(() => new Organization(nam, " ", dom));
        }

        [Fact]
        public void ContructorOfOrganizationShouldThowExceptionBecauseWrongDomain() {
            String nam = "foo";
            String loc = "Bar";
            Assert.Throws<GoedBezigException>(() => new Organization(nam, loc, "   "));
        }

        [Fact]
        public void OrganizationShouldRegisterUserAsParticipantInNewOrganization() {
            Organization org = new Organization("foo", "bar", "foo.bar");
            GUser user = new GUser("john.doe@foo.bar");
            org.Register(user);
            Assert.True(user.UserState is Participant);
        }

        [Fact]
        public void OrganizationShouldThrowExceptionBecauseAlreadyInOrganization() {
            Organization org = new Organization("foo", "bar", "foo.bar");
            Organization org2 = new Organization("foo1", "bar1", "foo.bar");
            GUser user = new GUser("john.doe@foo.bar", new Participant(org));
            Assert.Throws<GoedBezigException>(() => org2.Register(user));
        }

        [Fact]
        public void OrganizationShouldThrowExceptionBecauseWrongDomain() {
            Organization org = new Organization("foo", "bar", "foo.bar");
            GUser user = new GUser("john.doe@foo.ba");
            Assert.Throws<GoedBezigException>(() => org.Register(user));
        }

        [Fact]
        public void OrganizationShouldCreateOpenGroupWhenParticipantsGroupIsNull() {
            Organization org = new Organization("foo", "bar", "foo.bar");
            GUser user = new GUser("john.doe@foo.bar", new Participant(org));
            org.CreateGroup((user.UserState as Participant), "Open", false);
            Assert.True((user.UserState as Participant).Group != null);
        }

        [Fact]
        public void OrganizationShouldThrowExceptionBecauseAlreadyInGroup() {
            Organization org = new Organization("foo", "bar", "foo.bar");
            GUser user = new GUser("john.doe@foo.bar", new Participant(org));
            org.CreateGroup((user.UserState as Participant), "Open", false);
            Assert.Throws<GoedBezigException>(() => org.CreateGroup((user.UserState as Participant), "Open2", false));
        }

    }
}
