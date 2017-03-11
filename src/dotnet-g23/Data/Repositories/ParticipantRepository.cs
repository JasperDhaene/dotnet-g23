using System;
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

        public IEnumerable<Participant> GetAll()
        {
            return _participants
                .Include(p => p.Group)
                .Include(p => p.Lector)
                .Include(p => p.Organization)
                .Include(p => p.User)
                .Include(p => p.Invitations)
                .ToList();
        }



        public Participant GetBy(int userStateId)
        {
            return _participants
                .Include(p => p.Group)
                .Include(p => p.Lector)
                .Include(p => p.Organization)
                .Include(p => p.User)
                .Include(p => p.Invitations)
                .SingleOrDefault(p => p.UserStateId == userStateId);
        }

        public Participant GetByEmail(String email)
        {
            return _participants
                .Include(p => p.Group)
                .Include(p => p.Lector)
                .Include(p => p.Organization)
                .Include(p => p.User)
                .Include(p => p.Invitations)
                .SingleOrDefault(p => p.User.Email == email);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
