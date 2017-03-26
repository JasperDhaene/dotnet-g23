using System.Linq;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.State;
using Xunit;

namespace dotnet_g23.Tests.Models.State
{
    public class SubmittedStateTest
    {
        private Context Context { get; set; }
        private Group Group { get; set; }
        private Organization Organization { get; set; }
        private Participant Participant { get; set; }
        private GUser User { get; set; }

        private Motivation Motivation { get; set; }

        public SubmittedStateTest()
        {
            Context = new Context { CurrentState = new SubmittedState() };
            Group = new Group("Foobar");
            Organization = new Organization("Foo", "Bar", "foobar.com");
            Participant = new Participant(Organization);
            User = new GUser("john.doe@foobar.com", Participant);
            Motivation = new Motivation("My motivation");

            Participant.Organization = Organization;
            Organization.Participants.Add(Participant);

            User.UserState = Participant;
            Participant.User = User;

            Group.Organization = Organization;
            Organization.Groups.Add(Group);

            Group.Motivation = Motivation;
            Motivation.Group = Group;
        }

        [Fact]
        public void ThrowsExceptionOnUnsupportedMethods()
        {
            //Assert.Throws<StateException>(() => Context.Invite(null, null));
            //Assert.Throws<StateException>(() => Context.Register(null, null));
            //Assert.Throws<StateException>(() => Context.Submit(null));
            //Assert.Throws<StateException>(() => Context.Save(null, null));
            Assert.Throws<StateException>(() => Context.Grant(null, null));
            Assert.Throws<StateException>(() => Context.Announce(null, null));
            Assert.Throws<StateException>(() => Context.SetupAction(null, null, null, null));

            Assert.True(Context.CanInvite());
            Assert.False(Context.CanSetup());
        }

        /**
         * Invite
         * 
         * */
        [Fact]
        public void InviteShouldNotChangeState() {
            Context.Invite(Group, Participant);

            Assert.True(Context.CurrentState is SubmittedState);
        }

        [Fact]
        public void InviteShouldThrowOnInvalidParticipant()
        {
            Assert.Throws<StateException>(() => Context.Invite(Group, null));
        }

        [Fact]
        public void InviteShouldThrowOnInvitationPresent() { 
            Participant.Invitations.Add(new Invitation(Group, Participant));
            Assert.Throws<StateException>(() => Context.Invite(Group, Participant));
        }

        [Fact]
        public void InviteShouldThrowOnDifferentDomain() {
            User.Email = "foo@bar.com";
            Assert.Throws<StateException>(() => Context.Invite(Group, Participant));
        }

        [Fact]
        public void InviteShouldThrowOnGroupPresent()
        {
            Participant.Group = Group;
            Assert.Throws<StateException>(() => Context.Invite(Group, Participant));
        }

        [Fact]
        public void InviteShouldCreateInvite() {
            Context.Invite(Group, Participant);

            Assert.True(Participant.Invitations.Any());
            Assert.Equal(Group, Participant.Invitations.First().Group);
            Assert.Equal(Participant, Participant.Invitations.First().Participant);
        }

        /**
         * Register
         * 
         * */
        [Fact]
        public void RegisterShouldNotChangeState() {
            Context.Register(Group, Participant);

            Assert.True(Context.CurrentState is SubmittedState);
        }

        [Fact]
        public void RegisterShouldThrowOnInvalidParticipant()
        {
            Assert.Throws<StateException>(() => Context.Register(Group, null));
            Assert.Throws<StateException>(() => Context.Register(null, Participant));
        }

        [Fact]
        public void RegisterShouldThrowOnGroupPresent() {
            Participant.Group = Group;
            Assert.Throws<StateException>(() => Context.Register(Group, Participant));
        }

        [Fact]
        public void RegisterShouldThrowOnNoInvitationPresentWithClosedGroup() {
            Group.Closed = true;
            Assert.Throws<StateException>(() => Context.Register(Group, Participant));
        }

        [Fact]
        public void RegisterShouldRegisterParticipantWithOpenGroup() {
            Context.Register(Group, Participant);

            Assert.Equal(Group, Participant.Group);
            Assert.True(Group.Participants.Any());
        }

        [Fact]
        public void RegisterShouldRegisterParticipantWithClosedGroup()
        {
            Group.Closed = true;
            Participant.Invitations.Add(new Invitation(Group, Participant));

            Context.Register(Group, Participant);

            Assert.Equal(Group, Participant.Group);
            Assert.True(Group.Participants.Any());
        }

        /**
         * Submit
         * 
         * */
        [Fact]
        public void SubmitThrows()
        {
            Assert.Throws<StateException>(() => Context.Submit(Group));
        }
        
        /**
         * Save
         * 
         * */

        [Fact]
        public void SaveThrows()
        {
            Assert.Throws<StateException>(() => Context.Save(Group, Motivation));
        }
    }
}
