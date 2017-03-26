using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;

namespace dotnet_g23.Data.Repositories
{
    public class InvitationRepository : IInvitationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Invitation> _invitations;

        public InvitationRepository(ApplicationDbContext context)
        {
            _context = context;
            _invitations = context.Invitations;
        }

        public IEnumerable<Invitation> GetByParticipant(Participant participant)
        {
            return _invitations
                .Include(n => n.Participant)
                .Include(n => n.Group)
                .ThenInclude(n => n.Participants)
                .Where(n => n.Participant == participant);
        }

        public IEnumerable<Invitation> GetByGroup(Group group)
        {
            return _invitations
                .Include(n => n.Participant)
                .ThenInclude(p => p.User)
                .Include(n => n.Group)
                .Where(n => n.Group == group);
        }

        public void Destroy(Participant participant, Group group)
        {
            _invitations.RemoveRange(
                _invitations
                    .Include(n => n.Participant)
                    .Include(n => n.Group)
                    .Where(n => n.Participant == participant && n.Group == group)
            );
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}