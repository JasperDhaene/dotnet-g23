using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Data.Repositories
{
    public class CompanyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Company> _companies;

        public CompanyRepository(ApplicationDbContext context) {
            _context = context;
            _companies = context.Companies;
        }

        public IEnumerable<Company> GetAll() {
            return _companies
                .ToList();
        }

        public Company GetBy(int companyId) {
            return _companies
                .SingleOrDefault(c => c.CompanyId == companyId);
        }

        public IEnumerable<Company> GetByKeyword(String query) {
            return _companies
                .Where(org => org.Name.Contains(query) || org.Location.Contains(query))
                .ToList();
        }

        public Company GetByName(String orgName) {
            return _companies
                .SingleOrDefault(o => o.Name == orgName);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
