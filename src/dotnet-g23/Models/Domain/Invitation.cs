using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;

namespace dotnet_g23.Models.Domain
{
    public class Invitation
    {
        #region Properties
        public int InvitationId { get; private set; }
        public Participant Participant { get; private set; }
        public Group Group { get; private set; }
        #endregion

        #region Constructors
        public Invitation()
        {
        }
        public Invitation(Group fromGroup, Participant toParticipant)
        {
            Group = fromGroup;
            Participant = toParticipant;
        }
        #endregion
    }
}
