using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.State
{
    public class InitialState : State
    {
        public override void Invite(Context context, Group group, Participant participant)
        {
            if (participant == null)
                throw new StateException("Gebruiker niet gevonden in het systeem");

            if (participant.User.Domain != group.Organization.Domain)
                throw new StateException("Gebruiker behoort niet tot hetzelfde domein als de organisatie");

            if (participant.Group != null)
                throw new StateException("Gebruiker behoort al tot een groep");

            Invitation invitation = new Invitation(group, participant);
            participant.Invitations.Add(invitation);
        }
    }
}
