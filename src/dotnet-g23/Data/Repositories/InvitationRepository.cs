using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dotnet_g23.Models.Domain;

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

        public Invitation GetBy(int invitationId)
        {
            return _invitations
                .Include(n => n.Participant)
                .Include(n => n.Group)
                .SingleOrDefault(n => n.InvitationId == invitationId);
        }

        public IEnumerable<Invitation> GetByParticipant(Participant participant)
        {
            return _invitations
                .Include(n => n.Participant)
                .Include(n => n.Group)
                .Where(n => n.Participant == participant);
        }

        public IEnumerable<Invitation> GetAll()
        {
            return _invitations
                .Include(n => n.Participant)
                .Include(n => n.Group)
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
