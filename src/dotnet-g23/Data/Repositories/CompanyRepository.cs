using System.Collections.Generic;
using System.Linq;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace dotnet_g23.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DbSet<Company> _companies;
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
            _companies = context.Companies;
        }

        public IEnumerable<Company> GetAll()
        {
            return _companies
                .Include(c => c.Contacts)
                .Include(c => c.Label)
                .ToList();
        }

        public Company GetBy(int companyId)
        {
            return _companies
                .Include(c => c.Contacts)
                .Include(c => c.Label)
                .ThenInclude(label => label.Group)
                .SingleOrDefault(c => c.CompanyId == companyId);
        }

        public IEnumerable<Company> GetByKeyword(string query)
        {
            return _companies
                .Include(c => c.Contacts)
                .Include(c => c.Label)
                .Where(org => org.Name.Contains(query) || org.Address.Contains(query))
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}