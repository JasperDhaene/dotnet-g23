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
                .Include(n => n.User)
                .Include(n => n.Group)
                .SingleOrDefault(n => n.InvitationId == invitationId);
        }

        public IEnumerable<Invitation> GetByUser(GUser user)
        {
            return _invitations
                .Include(n => n.User)
                .Include(n => n.Group)
                .Where(n => n.User.UserId == user.UserId);
        }

        public IEnumerable<Invitation> GetAll()
        {
            return _invitations
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
