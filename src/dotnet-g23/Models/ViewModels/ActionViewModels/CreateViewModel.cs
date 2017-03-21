using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Action = dotnet_g23.Models.Domain.Action;

namespace dotnet_g23.Models.ViewModels.ActionViewModels
{
    public class CreateViewModel
    {
        public Group Group { get; set; }
        public Action Action { get; set; }

    }
}
