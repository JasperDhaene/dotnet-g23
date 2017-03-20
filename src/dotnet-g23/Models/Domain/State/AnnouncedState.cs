using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class AnnouncedState : State
    {
        public override Post Announce(Context context, Label label, String message, Byte[] logo)
        {
            throw new StateException("Er werd al een bericht gepubliceerd");
        }
    }
}
