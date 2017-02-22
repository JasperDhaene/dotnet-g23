using dotnet_g23.Models.Domain;
using System;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class GroupTest
    {
        [Fact]
        public void ConstructorShouldCreateNewClosedGroup()
        {
            Group g = new Group("ClosedGroup");
            Assert.Equal("ClosedGroup", g.Name);
            Assert.True(g.GetIsClosed());
        }

        [Fact]
        public void ConstructorShouldCreateNewOpenGroup()
        {
            Group g = new Group("OpenGroup", false);
            Assert.Equal("ClosedGroup", g.Name);
            Assert.False(g.GetIsClosed());
        }

        [Fact]
        public void ConstructorShouldCreateNewClosedGroupWithOverloadedConstructor()
        {
            Group g = new Group("ClosedGroup", true);
            Assert.Equal("ClosedGroup", g.Name);
            Assert.True(g.GetIsClosed());
        }

        [Fact]
        public void ConstructorShouldNotCreateNewClosedGroupBecauseNameIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Group(null));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewClosedGroupBecauseNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Group(""));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewClosedGroupBecauseNameIsSpaces()
        {
            Assert.Throws<ArgumentException>(() => new Group("          "));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewOpenGroupBecauseNameIsSpaces()
        {
            Assert.Throws<ArgumentException>(() => new Group("          ", false));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewOpenGroupBecauseNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Group("", false));
        }

        [Fact]
        public void ConstructorShouldNotCreateNewOpenGroupBecauseNameIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Group(null, false));
        }

        [Fact]
        public void ParticipantsAddedToCollectionOfParticipantsInGroup()
        {
            Group group = new Group("group");
            group.Participants.Add(new Participant());
            group.Participants.Add(new Participant());
            group.Participants.Add(new Participant());
            group.Participants.Add(new Participant());
            Assert.True(group.Participants.Count > 0);
            Assert.Equal(4, group.Participants.Count);
        }
    }
}
