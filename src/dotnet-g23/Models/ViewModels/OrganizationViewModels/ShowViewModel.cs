using System.Collections.Generic;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Models.ViewModels.OrganizationViewModels
{
    public class ShowViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public Organization Organization { get; set; }
    }
}