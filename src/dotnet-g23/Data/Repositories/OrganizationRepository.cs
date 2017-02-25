using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Data.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Organization> _organizations;

        public OrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
            _organizations = context.Organizations;
        }

        public IEnumerable<Organization> GetAll()
        {
            return _organizations
                .Include(o => o.GBOrganization)
                .ToList();
        }

        public Organization GetBy(int OrganizationId)
        {
            return _organizations
                .Include(o => o.GBOrganization)
                .SingleOrDefault(o => o.OrganizationId == OrganizationId);
        }

        public Organization GetByName(string orgName)
        {
            return _organizations
                .Include(o => o.GBOrganization)
                .SingleOrDefault(o => o.Name  == orgName);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
