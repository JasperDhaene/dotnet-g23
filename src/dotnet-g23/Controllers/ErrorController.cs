using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers {
    public class ErrorController : Controller {
        [HttpGet]
        [Route("/Error")]
        public IActionResult Error() {
            return View();
        }
    }
}