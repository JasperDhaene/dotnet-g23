using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class InvitationTest
    {
        [Fact]
        public void NewInvitationIsUnread()
        {
            Invitation invitation = new Invitation(null, null, null);
            Assert.False(invitation.IsRead);
        }

        [Fact]
        public void NewInvitationIsRead()
        {
            Invitation invitation = new Invitation(null, null, null);
            invitation.Read();
            Assert.True(invitation.IsRead);
        }
    }
}
