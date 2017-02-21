using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Data.Repositories
{
    public class GADOrganizationRepository : IGADOrganizationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<GADOrganization> _gadOrganizations;

        public GADOrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
            _gadOrganizations = context.GADOrganizations;
        }

        public IEnumerable<GADOrganization> GetAll()
        {
            return _gadOrganizations.Include(o => o.OrganizationRole).ToList();
        }

        public GADOrganization GetBy(int orgId)
        {
            return _gadOrganizations.Include(o => o.OrganizationRole)
                .SingleOrDefault(o => o.OrganizationId == orgId);
        }

        public GADOrganization GetByName(string orgName)
        {
            return _gadOrganizations.Include(o => o.OrganizationRole)
                .SingleOrDefault(o => o.Name == orgName);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
