using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain.State;
using Xunit;

namespace dotnet_g23.Tests.Models.State
{
    public class StateTest
    {
        [Fact]
        public void NewContextHasInitialState()
        {
            Context context = new Context();
            Assert.Equal(typeof(InitialState), context.CurrentState.GetType());
        }

        [Fact]
        public void InitialStateThrowsExceptionOnPrevious()
        {
            Context context = new Context();

            Assert.Throws<StateException>(() => context.PreviousState());
        }

        [Fact]
        public void SubmittedStateFollowsInitialState()
        {
            Context context = new Context();
            context.NextState();
            Assert.Equal(typeof(SubmittedState), context.CurrentState.GetType());
        }

        [Fact]
        public void SubmittedStateReturnsToInitialStateOnPrevious()
        {
            Context context = new Context();
            context.NextState();
            context.PreviousState();
            Assert.Equal(typeof(InitialState), context.CurrentState.GetType());
        }

        [Fact]
        public void ApprovedStateFollowsSubmittedState()
        {
            Context context = new Context();
            context.NextState();
            context.NextState();
            Assert.Equal(typeof(ApprovedState), context.CurrentState.GetType());
        }

        [Fact]
        public void ApprovedStateThrowsExceptionOnNext()
        {
            Context context = new Context();
            context.NextState();
            context.NextState();
            Assert.Throws<StateException>(() => context.NextState());
        }

        [Fact]
        public void ApprovedStateThrowsExceptionOnPrevious()
        {
            Context context = new Context();
            context.NextState();
            context.NextState();
            Assert.Throws<StateException>(() => context.PreviousState());
        }
    }
}
