using System.Collections.Generic;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IParticipantRepository
    {
        Participant GetBy(int userStateId);
        Participant GetByUser(int userId);
        IEnumerable<Participant> GetAll();
        void SaveChanges();
    }
}
