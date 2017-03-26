using System.Collections.Generic;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Company GetBy(int companyId);
        IEnumerable<Company> GetAll();
        void SaveChanges();
        IEnumerable<Company> GetByKeyword(string query);
    }
}