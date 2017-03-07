using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.ViewModels.MotivationViewModels
{
    public class CheckViewModel
    {
        public Motivation UnnaprovedMotivation { get; set; }

        public Motivation ApprovedMotivation { get; set; }
    }
}
