using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class GroupTest
    {
        [Fact]
        public void ConstructorShouldCreateNewOpenGroup() {
            Group group = new Group("OpenGroup");
            Assert.False(group.Closed);
            Assert.True(group.Name.Equals("OpenGroup"));
        }

        [Fact]
        public void ConstructorShouldCreateNewOpenGroupWithoutParticipantsActionsInvitations() {
            Group group = new Group("OpenGroup");
            Assert.True(group.Invitations.Count == 0);
            Assert.True(group.Participants.Count == 0);
            Assert.True(group.Actions.Count == 0);
        }

        [Fact]
        public void ConstructorShouldCreateNewClosedGroup() {
            Group group = new Group("ClosedGroup", true);
            Assert.True(group.Closed);
        }

        [Fact]
        public void ConstructorShouldThrowExceptionBecauseWrongName() {
            Assert.Throws<GoedBezigException>(() => new Group("   "));
        }

    }
}
