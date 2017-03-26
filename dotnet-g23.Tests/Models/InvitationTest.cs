using dotnet_g23.Models.Domain;
using Xunit;

namespace dotnet_g23.Tests.Models
{
    public class InvitationTest
    {
        [Fact]
        public void ConstructorShouldCreateNewInvitation() {
            Group group = new Group("Open Group");
            GUser user = new GUser("john.doe@foo.bar", new Participant(new Organization("Foo", "Bar", "foo.bar")));
            Invitation inv = new Invitation(group, user.UserState as Participant);
            Assert.Equal(group.Name, inv.Group.Name);
        }
    }
}
