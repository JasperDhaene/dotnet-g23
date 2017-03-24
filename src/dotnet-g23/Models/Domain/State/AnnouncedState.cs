using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class AnnouncedState : State
    {
        public override Post Announce(Context context, Label label, String message)
        {
            throw new StateException("Er werd al een bericht gepubliceerd");
        }

        public override void SetupAction(Context context, Group group,String title, String description, DateTime? date)
        {
            new GrantedState().SetupAction(context, group, title, description, date);
        }

        public override Boolean CanSetup() { return true; }
    }
}
