using dotnet_g23.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.ViewModels.MotivationViewModels
{
    public class IndexViewModel
    {
        public Group SubscribedGroup { get; set; }

        public Motivation GroupMotivation { get; set; }
    }
}
