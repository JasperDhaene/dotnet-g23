using System.Collections.Generic;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Models.ViewModels.LabelViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Company> Companies { get; set; }
    }
}