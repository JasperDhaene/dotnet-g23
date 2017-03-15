using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Company> _companies;

        public CompanyRepository(ApplicationDbContext context) {
            _context = context;
            _companies = context.Companies;
        }

        public IEnumerable<Company> GetAll() {
            return _companies
                .Include(c => c.Contacts)
                .Include(c => c.Label)
                .ToList();
        }

        public Company GetBy(int companyId) {
            return _companies
                .Include(c => c.Contacts)
                .Include(c => c.Label)
                .SingleOrDefault(c => c.CompanyId == companyId);
        }

        public IEnumerable<Company> GetByKeyword(String query) {
            return _companies
                .Include(c => c.Contacts)
                .Include(c => c.Label)
                .Where(org => org.Name.Contains(query) || org.Address.Contains(query))
                .ToList();
        }

        public Company GetByName(String orgName) {
            return _companies
                .Include(c => c.Contacts)
                .Include(c => c.Label)
                .SingleOrDefault(o => o.Name == orgName);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
