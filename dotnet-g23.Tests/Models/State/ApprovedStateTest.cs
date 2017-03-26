using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.State;
using Xunit;

namespace dotnet_g23.Tests.Models.State
{
    public class ApprovedStateTest
    {
        private Context Context { get; set; }
        private Group Group { get; set; }
        private Company Company { get; set; }

        private Motivation Motivation { get; set; }

        public ApprovedStateTest()
        {
            Context = new Context { CurrentState = new ApprovedState() };
            Group = new Group("Foobar");
            Motivation = new Motivation("My motivation");
            Motivation.Approved = true;
            Company = new Company("Name", "Description", "Address", "Website", "Email", new byte[1]);

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
            //Assert.Throws<StateException>(() => Context.Grant(null, null));
            Assert.Throws<StateException>(() => Context.Announce(null, null));
            Assert.Throws<StateException>(() => Context.SetupAction(null, null, null, null));

            Assert.False(Context.CanInvite());
            Assert.False(Context.CanSetup());
        }

        /**
         * Grant
         * 
         * */
        [Fact]
        public void GrantThrowsOnLabelPresent()
        {
            Label label = new Label(Group, Company);
            Company.Label = label;

            Assert.Throws<StateException>(() => Context.Grant(Group, Company));
        }

        [Fact]
        public void GrantCreatesLabel()
        {
            Context.Grant(Group, Company);

            Assert.NotNull(Company.Label);
            Assert.Equal(Group, Company.Label.Group);

            Assert.NotNull(Group.Label);
            Assert.Equal(Company, Group.Label.Company);
        }

        [Fact]
        public void GrantChangesState()
        {
            Context.Grant(Group, Company);

            Assert.True(Context.CurrentState is GrantedState);
        }
    }
}
