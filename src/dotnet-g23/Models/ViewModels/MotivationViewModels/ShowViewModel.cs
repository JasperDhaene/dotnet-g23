using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.ViewModels.MotivationViewModels
{
    public class ShowViewModel
    {
        public Group Group { get; set; }

        public Motivation Motivation { get; set; }

    }
}
