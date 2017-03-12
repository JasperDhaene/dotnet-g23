using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State {
    public class SubmittedState : State {
        public override void HandleNext(Context context) {
            context.CurrentState = new ApprovedState();
        }

        public override void HandlePrevious(Context context) {
            context.CurrentState = new InitialState();
        }
    }
}