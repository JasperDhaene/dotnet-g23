using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Models.ViewModels.OrganizationViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Organization> Organizations { get; set; }
        public Organization SubscribedOrganization { get; set; }
    }
}
