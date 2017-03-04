using System.Collections.Generic;
using System.Linq;
using dotnet_g23.Models.Domain;
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

        public IEnumerable<Participant> GetAll()
        {
            return _participants
                .Include(p => p.Group)
                .Include(p => p.Lector)
                .Include(p => p.Organization)
                .Include(p => p.User)
                .ToList();
        }



        public Participant GetBy(int userStateId)
        {
            return _participants
                .Include(p => p.Group)
                .Include(p => p.Lector)
                .Include(p => p.Organization)
                .Include(p => p.User)
                .SingleOrDefault(p => p.UserStateId == userStateId);
        }

        public Participant GetByUser(int userId)
        {
            return _participants
                .Include(p => p.Group)
                .Include(p => p.Lector)
                .Include(p => p.Organization)
                .Include(p => p.User)
                .SingleOrDefault(p => p.User.UserId == userId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
