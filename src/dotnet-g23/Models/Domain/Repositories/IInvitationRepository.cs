using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public interface IInvitationRepository
    {
        IEnumerable<Invitation> GetByParticipant(Participant participant);
        IEnumerable<Invitation> GetByGroup(Group group);
        void Destroy(Participant participant, Group group);
        void SaveChanges();
    }
}
