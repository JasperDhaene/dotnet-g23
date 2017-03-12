using System;
using System.Collections.Generic;

namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IOrganizationRepository
    {
        Organization GetBy(int organizationId);
        Organization GetByName(String orgName);
        IEnumerable<Organization> GetByDomain(String domain);
        IEnumerable<Organization> GetAll();
        void SaveChanges();
        IEnumerable<Organization> GetByKeyword(String query);
    }
}
