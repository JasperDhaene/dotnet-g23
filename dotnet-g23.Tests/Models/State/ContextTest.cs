using dotnet_g23.Models.Domain.State;
using Xunit;

namespace dotnet_g23.Tests.Models.State
{
    public class ContextTest
    {
        private Context Context { get; set; }

        public ContextTest()
        {
            Context = new Context();
        }

        [Fact]
        public void ConstructorShouldCreateContextWithCurrentStateAsInitialState() {
            Assert.True(Context.CurrentState is InitialState);
        }

        [Fact]
        public void SerializableStateShouldReturnString()
        {
            Assert.NotNull(Context.SerializableState);
            Assert.NotEmpty(Context.SerializableState);
        }

        [Fact]
        public void ContextShouldSerializeStateCorrectly() {
            Context context = new Context { CurrentState = new ApprovedState() };
            Assert.Contains("dotnet_g23.Models.Domain.State.ApprovedState", context.SerializableState);
        }

        [Fact]
        public void ContextShouldDeSerializeStateCorrectly() {
            Context context = new Context {SerializableState = "dotnet_g23.Models.Domain.State.AnnouncedState" };
            Assert.True(context.CurrentState is AnnouncedState);
        }
    }
}
