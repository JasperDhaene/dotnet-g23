using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IContactRepository
    {
        Contact GetBy(int contactId);
        Contact GetByEmail(String email);
        IEnumerable<Contact> GetAll();
        IEnumerable<Contact> GetByCompany(Company company);
        void SaveChanges();
    }
}
