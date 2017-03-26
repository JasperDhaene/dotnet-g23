using System;
using System.Collections.Generic;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IParticipantRepository
    {
        Participant GetByEmail(String email);
        IEnumerable<Participant> GetByGroup(Group group);
        void SaveChanges();
    }
}