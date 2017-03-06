using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using dotnet_g23.Filters;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.Domain;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_g23.Controllers {
    [Authorize]
    [ServiceFilter(typeof(UserFilter))]
    public class MotivationController : Controller {
        #region Fields
        private readonly IGroupRepository _groupRepository;
        #endregion

        public MotivationController(IGroupRepository groupRepository) {
            _groupRepository = groupRepository;
        }

        public IActionResult Index(Organization organization) {
            IEnumerable<Group> groups = _groupRepository.GetByOrganization(organization);
            IEnumerable<Motivation> motivationsToWrite;
            return View();
        }

        [Authorize(Policy = "participant")]
        public IActionResult RegisterMotivation() {
            return View();
        }

        [Authorize(Policy = "lector")]
        public IActionResult CheckMotivation(GUser user) {
            return View();
        }
    }
}
