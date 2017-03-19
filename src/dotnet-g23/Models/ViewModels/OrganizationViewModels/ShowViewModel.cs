using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.ViewModels.OrganizationViewModels
{
    public class ShowViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
