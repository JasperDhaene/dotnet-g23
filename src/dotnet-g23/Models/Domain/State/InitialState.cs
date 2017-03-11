using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class InitialState : State
    {
        public InitialState() : base(0)
        {
        }

        public override void HandleNext()
        {
            Context.CurrentState = new SubmittedState();
        }
    }
}
