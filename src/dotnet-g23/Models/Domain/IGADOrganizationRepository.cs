using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public interface IGADOrganizationRepository
    {
        Organization GetBy(int orgId);
        Organization GetByName(String orgName);
        IEnumerable<Organization> GetAll();
        void SaveChanges();
    }
}
