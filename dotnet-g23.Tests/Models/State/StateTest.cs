using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.State;
using Xunit;

namespace dotnet_g23.Tests.Models.State {
    public class StateTest {
        [Fact]
        public void NewContextHasInitialState() {
            Context context = new Context();
            Assert.IsType<InitialState>(context.CurrentState);
        }
    }
}