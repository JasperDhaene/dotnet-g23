using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class AnnouncedState : State
    {
        public override void Announce(Context context, Label label, String message)
        {
            throw new StateException("Er werd al een bericht gepubliceerd");
        }
    }
}
