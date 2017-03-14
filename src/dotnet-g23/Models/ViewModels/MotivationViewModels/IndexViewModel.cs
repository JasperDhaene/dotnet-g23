using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g23.Models.ViewModels.MotivationViewModels
{
    public class IndexViewModel
    {
        public Group Group { get; set; }

        public Motivation Motivation { get; set; }

        public SelectList PossibleCompaniesList { get; set; }

        public IndexViewModel() {
            //int[] maanden = new int[] { 1, 2, 3, 6, 12, 18, 24 };
            //List<SelectListItem> items = new List<SelectListItem>();
            //foreach (int maand in maanden)
            //    items.Add(new SelectListItem() { Text = maand + " " + ((maand == 1) ? "maand" : "maanden"), Value = maand.ToString() });
            //PossibleCompaniesList = new SelectList(items, "Value", "Text");
        }

    }
}
