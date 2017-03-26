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
    }
}
