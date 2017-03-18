using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class SubmittedState : InitialState
    {
        public override void Submit(Context context, Group group)
        {
            throw new StateException("Motivatie is reeds verzonden");
        }
    }
}
