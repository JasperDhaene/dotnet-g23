using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class InitialState : State
    {
        public override void HandleNext(Context context)
        {
            context.CurrentState = new SubmittedState();
        }
    }
}
