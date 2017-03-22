using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_g23.Tests.Models.State
{
    public class ContextTest
    {
        [Fact]
        public void ConstructorShouldCreateContextWithCurrentStateAsInitialState() {
            Context context = new Context();
            Assert.True(context.CurrentState is InitialState);
        }

        //[Fact]
        //public void ContextInviteShouldInviteNewParticipant() {
        //    Context context = new Context();
        //    GUser user = new GUser("john.doe@foobar.com", new Participant(new Organization("Foo", "Bar", "foobar.com")));
        //    Group gr = new Group("Open");
        //    context.Invite(gr, user.UserState as Participant);
        //    Assert.True(context.CurrentState is InitialState);
        //}

        //[Fact]
        //public void ContextRegisterShouldAddParticipantToGroup() {
        //    Context context = new Context();
        //    GUser user = new GUser("john.doe@foobar.com", new Participant(new Organization("Foo", "Bar", "foobar.com")));
        //    Group gr = new Group("Open");
        //    context.Register(gr, user.UserState as Participant);
        //    Assert.True(context.CurrentState is InitialState);
        //}

        //[Fact]
        //public void ContextSubmitShouldChangeStateToSubmit() {
        //    Context context = new Context();
        //    GUser user = new GUser("john.doe@foobar.com", new Participant(new Organization("Foo", "Bar", "foobar.com")));
        //    Group gr = new Group("Open");
        //    context.Submit(gr, user.UserState as Participant);
        //    Assert.True(context.CurrentState is SubmitState);
        //}

        //[Fact]
        //public void ContextGrantShouldChangeStateToGranted() {
        //    Context context = new Context();
        //    GUser user = new GUser("john.doe@foobar.com", new Participant(new Organization("Foo", "Bar", "foobar.com")));
        //    Group gr = new Group("Open");
        //    context.Grant(gr, user.UserState as Participant);
        //    Assert.True(context.CurrentState is GrantedState);
        //}

        //[Fact]
        //public void ContextAnnounceShouldChangeStateToAnnounced() {
        //    Context context = new Context();
        //    GUser user = new GUser("john.doe@foobar.com", new Participant(new Organization("Foo", "Bar", "foobar.com")));
        //    Group gr = new Group("Open");
        //    Company comp = new Company("Foobar", "Foobar", "Foobar", "foobar.com", "foo@foobar.com");
        //    Label label = new label(gr, comp);
        //    context.Announce(label, gr, user.UserState as Participant);
        //    Assert.True(context.CurrentState is AnnouncedState);
        //}
    }
}
