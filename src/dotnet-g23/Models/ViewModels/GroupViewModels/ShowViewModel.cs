using System.Collections.Generic;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Models.ViewModels.GroupViewModels
{
    public class ShowViewModel
    {
        public IEnumerable<Invitation> Invitations;
        public IEnumerable<Participant> Participants;
        public Group Group { get; set; }
    }
}