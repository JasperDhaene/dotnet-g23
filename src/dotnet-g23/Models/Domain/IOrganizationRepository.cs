using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public interface IOrganizationRepository
    {
        Organization GetBy(int organizationId);
        Organization GetByName(String orgName);
        IEnumerable<Organization> GetByDomain(String domain);
        IEnumerable<Organization> GetAll();
        void SaveChanges();
    }
}
