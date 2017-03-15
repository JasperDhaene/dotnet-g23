using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Data.Repositories
{
    public class ContactRepository : IContactRepository {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Contact> _contacts;

        public ContactRepository(ApplicationDbContext context) {
            _context = context;
            _contacts = context.Contacts;
        }
        public IEnumerable<Contact> GetAll() {
            return _contacts.ToList();
        }

        public Contact GetBy(int contactId) {
            return _contacts
                .Include(c => c.Title)
                .Include(c => c.FirstName)
                .Include(c => c.LastName)
                .Include(c => c.Company)
                .Include(c => c.Email)
                .SingleOrDefault(c => c.ContactId == contactId);
        }

        public IEnumerable<Contact> GetByCompany(Company company) {
            return _contacts
                .Include(c => c.Title)
                .Include(c => c.FirstName)
                .Include(c => c.LastName)
                .Include(c => c.Company)
                .Include(c => c.Email)
                .Where(p => p.Company != null && p.Company == company)
                .ToList();
        }

        public Contact GetByEmail(string email) {
            return _contacts
                .Include(c => c.Title)
                .Include(c => c.FirstName)
                .Include(c => c.LastName)
                .Include(c => c.Company)
                .Include(c => c.Email)
                .SingleOrDefault(c => c.Email == email);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
