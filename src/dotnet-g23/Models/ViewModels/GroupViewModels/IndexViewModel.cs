using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Models.ViewModels.GroupViewModels {
    public class IndexViewModel {
        public IEnumerable<Group> InvitedGroups { get; set; }
        public IEnumerable<Group> OpenGroups { get; set; }
        public Group SubscribedGroup { get; set; }
        public Organization Organization { get; set; }
    }
}