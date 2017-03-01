using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Group> _groups;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
            _groups = context.Groups;
        }

        public IEnumerable<Group> GetAll()
        {
            return _groups
                .Include(g => g.Organization)
                .Include(g => g.Motivation)
                .Include(g => g.Lectors)
                .Include(g => g.Participants)
                .ToList();
        }

        public Group GetBy(int groupId)
        {
            return _groups
                .Include(g => g.Organization)
                .Include(g => g.Motivation)
                .Include(g => g.Lectors)
                .Include(g => g.Participants)
                .SingleOrDefault(g => g.GroupId == groupId);
        }

        public Group GetByName(string groupName)
        {
            return _groups
                .Include(g => g.Organization)
                .Include(g => g.Motivation)
                .Include(g => g.Lectors)
                .Include(g => g.Participants)
                .SingleOrDefault(g => g.Name == groupName);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
