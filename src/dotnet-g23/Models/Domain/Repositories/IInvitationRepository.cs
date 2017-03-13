﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public interface IInvitationRepository
    {
        Invitation GetBy(int invitationId);
        IEnumerable<Invitation> GetByParticipant(Participant participant);
        IEnumerable<Invitation> GetByGroup(Group group);
        IEnumerable<Invitation> GetAll();
        void Destroy(Participant participant, Group group);
        void SaveChanges();
    }
}
