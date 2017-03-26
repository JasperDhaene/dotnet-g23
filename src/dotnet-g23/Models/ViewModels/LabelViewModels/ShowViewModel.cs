using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.ViewModels.LabelViewModels
{
    public class ShowViewModel
    {
        public Company Company { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }

        public Group Group { get; set; }

        public Motivation Motivation { get; set; }

        public Organization Organization { get; set; }

        public Label Label { get; set; }
    }
}
