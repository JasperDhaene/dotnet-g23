using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers
{
    public class ActionController : Controller
    {
        // GET /Groups/{id}/Action
        [Route("Groups/{id}/Action")]
        public IActionResult New(Participant participant)
        {
            return View();
        }
    }
}
