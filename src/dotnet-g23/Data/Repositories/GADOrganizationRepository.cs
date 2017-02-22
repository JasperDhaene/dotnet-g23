using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

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

        public GADOrganization GetBy(int orgId)
        {
            return _gadOrganizations.Include(u => u.OrganizationRole)
                            .SingleOrDefault(u => u.OrganizationId == orgId);
        }

        public GADOrganization GetByName(string orgName)
        {
            return _gadOrganizations.Include(u => u.OrganizationRole)
                            .SingleOrDefault(u => u.Name == orgName);
        }

        public IEnumerable<GADOrganization> GetAll()
        {
            return _gadOrganizations.Include(u => u.OrganizationRole).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
