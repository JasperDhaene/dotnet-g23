using System.Collections.Generic;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IInvitationRepository
    {
        IEnumerable<Invitation> GetByParticipant(Participant participant);
        IEnumerable<Invitation> GetByGroup(Group group);
        void Destroy(Participant participant, Group group);
        void SaveChanges();
    }
}