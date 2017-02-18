using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.Domain
{
    public interface IOrganizationRepository
    {
        Organization GetBy(String naam);
        Organization GetByLocation(String locatie);
        IEnumerable<Organization> GetAll();
        void SaveChanges();
    }
}
