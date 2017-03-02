using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_g23.Controllers
{
    
    public class MotivationController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "participant")]
        public IActionResult RegisterMotivation() {
            return View();
        }

        [Authorize(Policy ="lector")]
        public IActionResult CheckMotivation() {
            return View();
        }
    }
}
