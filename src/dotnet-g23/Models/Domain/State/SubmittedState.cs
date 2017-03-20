using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class SubmittedState : State
    {
        public override void Invite(Context context, Group group, Participant participant)
        {
            // DRY
            new InitialState().Invite(context, group, participant);
        }

        public override void Register(Context context, Group group, Participant participant)
        {
            // DRY
            new InitialState().Register(context, group, participant);
        }

        public override void Submit(Context context, Group group)
        {
            throw new StateException("Motivatie is reeds verzonden");
        }
    }
}
