using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Company GetBy(int companyId);
        IEnumerable<Company> GetAll();
        void SaveChanges();
        IEnumerable<Company> GetByKeyword(String query);
    }
}