using System.Collections.Generic;
using System.Linq;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace dotnet_g23.Data.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Participant> _participants;

        public ParticipantRepository(ApplicationDbContext context)
        {
            _context = context;
            _participants = context.Participants;
        }

        public Participant GetByEmail(string email)
        {
            return _participants
                .Include(p => p.Group)
                .Include(p => p.Lector)
                .Include(p => p.Organization)
                .Include(p => p.User)
                .Include(p => p.Invitations)
                .SingleOrDefault(p => p.User.Email == email);
        }

        public IEnumerable<Participant> GetByGroup(Group group)
        {
            return _participants
                .Include(p => p.Group)
                .Include(p => p.Lector)
                .Include(p => p.Organization)
                .Include(p => p.User)
                .Include(p => p.Invitations)
                .Where(p => (p.Group != null) && (p.Group == group))
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}