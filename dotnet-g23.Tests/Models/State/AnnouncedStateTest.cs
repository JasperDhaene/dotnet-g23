using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.State;
using Xunit;

namespace dotnet_g23.Tests.Models.State
{
    public class AnnouncedStateTest
    {
        private Context Context { get; set; }
        private Group Group { get; set; }
        private Company Company { get; set; }
        private Label Label { get; set; }
        private Post Post { get; set; }

        private Motivation Motivation { get; set; }

        public AnnouncedStateTest()
        {
            Context = new Context { CurrentState = new AnnouncedState() };
            Group = new Group("Foobar");
            Motivation = new Motivation("My motivation");
            Motivation.Approved = true;
            Company = new Company("Name", "Description", "Address", "Website", "Email", new byte[1]);
            Label = new Label(Group, Company);
            Post = new Post("Announcement");

            Label.Post = Post;
            Post.Label = Label;

            Group.Label = Label;
            Company.Label = Label;

            Group.Motivation = Motivation;
            Motivation.Group = Group;
        }

        [Fact]
        public void ThrowsExceptionOnUnsupportedMethods()
        {
            Assert.Throws<StateException>(() => Context.Invite(Group, null));
            Assert.Throws<StateException>(() => Context.Register(Group, null));
            Assert.Throws<StateException>(() => Context.Submit(null));
            Assert.Throws<StateException>(() => Context.Save(null, null));
            Assert.Throws<StateException>(() => Context.Grant(null, null));
            //Assert.Throws<StateException>(() => Context.Announce(null, null));
            //Assert.Throws<StateException>(() => Context.SetupAction(null, null, null, null));

            Assert.False(Context.CanInvite());
            Assert.True(Context.CanSetup());
        }
        
        /**
         * Announce
         * 
         * */

        [Fact]
        public void AnnounceThrows()
        {
            Assert.Throws<StateException>(() => Context.Announce(Label, "Announcement"));
        }

        /**
         * SetupAction
         * 
         * */

        [Fact]
        public void SetupActionShouldCreateAction() {
            Context.SetupAction(Group, "Title", "Description", null);

            Assert.True(Group.Actions.Any());
            Assert.Equal("Title", Group.Actions.First().Title);
            Assert.Null(Group.Actions.First().Date);
        }

        public void SetupActionShouldCreateEvent() {
            DateTime date = DateTime.Now;
            Context.SetupAction(Group, "Title", "Description", null);

            Assert.True(Group.Actions.Any());
            Assert.Equal("Title", Group.Actions.First().Title);
            Assert.NotNull(Group.Actions.First().Date);
        }
    }
}
