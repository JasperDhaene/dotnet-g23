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

        [Fact]
        public void InitialStateThrowsExceptionOnPrevious() {
            Context context = new Context();

            Assert.Throws<StateException>(() => context.PreviousState());
        }

        [Fact]
        public void SubmittedStateFollowsInitialState() {
            Context context = new Context();
            context.NextState();
            Assert.IsType<SubmittedState>(context.CurrentState);
        }

        [Fact]
        public void SubmittedStateReturnsToInitialStateOnPrevious() {
            Context context = new Context();
            context.NextState();
            context.PreviousState();
            Assert.IsType<InitialState>(context.CurrentState);
        }

        [Fact]
        public void ApprovedStateFollowsSubmittedState() {
            Context context = new Context();
            context.NextState();
            context.NextState();
            Assert.IsType<ApprovedState>(context.CurrentState);
        }

        [Fact]
        public void ApprovedStateThrowsExceptionOnNext() {
            Context context = new Context();
            context.NextState();
            context.NextState();
            Assert.Throws<StateException>(() => context.NextState());
        }

        [Fact]
        public void ApprovedStateThrowsExceptionOnPrevious() {
            Context context = new Context();
            context.NextState();
            context.NextState();
            Assert.Throws<StateException>(() => context.PreviousState());
        }

        [Fact]
        public void GroupInitialStateSerializes() {
            Group group = new Group("groupname");
            group.Context.CurrentState = new InitialState();
            Assert.IsType<InitialState>(group.Context.CurrentState);
            String serializedState = group.StateContext;

            Group deserialized = new Group("groupname2");
            deserialized.StateContext = serializedState;
            Assert.IsType<InitialState>(group.Context.CurrentState);
        }

        [Fact]
        public void GroupSubmittedStateSerializes() {
            Group group = new Group("groupname");
            group.Context.CurrentState = new SubmittedState();
            Assert.IsType<SubmittedState>(group.Context.CurrentState);
            String serializedState = group.StateContext;

            Group deserialized = new Group("groupname2");
            deserialized.StateContext = serializedState;
            Assert.IsType<SubmittedState>(group.Context.CurrentState);
        }

        [Fact]
        public void GroupApprovedStateSerializes() {
            Group group = new Group("groupname");
            group.Context.CurrentState = new ApprovedState();
            Assert.IsType<ApprovedState>(group.Context.CurrentState);
            String serializedState = group.StateContext;

            Group deserialized = new Group("groupname2");
            deserialized.StateContext = serializedState;
            Assert.IsType<ApprovedState>(group.Context.CurrentState);
        }
    }
}