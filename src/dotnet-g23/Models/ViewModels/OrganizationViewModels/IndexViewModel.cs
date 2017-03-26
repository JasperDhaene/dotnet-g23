using System.Collections.Generic;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Models.ViewModels.OrganizationViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Organization> Organizations { get; set; }
        public Organization SubscribedOrganization { get; set; }
        public GUser User { get; set; }
    }
}