using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public interface IGADOrganizationRepository
    {
        GADOrganization GetBy(int orgId);
        GADOrganization GetByName(String orgName);
        IEnumerable<GADOrganization> GetAll();
        void SaveChanges();
    }
}
