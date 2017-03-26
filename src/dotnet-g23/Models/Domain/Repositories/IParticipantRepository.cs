using System.Collections.Generic;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IParticipantRepository
    {
        Participant GetByEmail(string email);
        IEnumerable<Participant> GetByGroup(Group group);
        void SaveChanges();
    }
}