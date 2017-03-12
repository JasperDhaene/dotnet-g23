using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class SubmittedState : State
    {
        public SubmittedState() : base(1)
        {
        }

        public override void HandleNext()
        {
            Context.CurrentState = new ApprovedState();
        }

        public override void HandlePrevious()
        {
            Context.CurrentState = new InitialState();
        }
    }
}
