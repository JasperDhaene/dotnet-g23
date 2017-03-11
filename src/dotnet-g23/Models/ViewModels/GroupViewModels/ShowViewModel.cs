using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Models.ViewModels.GroupViewModels
{
    public class ShowViewModel
    {
        public Group Group { get; set; }
        public IEnumerable<Participant> Participants;
    }
}
