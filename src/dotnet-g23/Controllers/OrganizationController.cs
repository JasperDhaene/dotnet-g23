using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Data.Repositories;
using dotnet_g23.Filters;
using dotnet_g23.Helpers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.ViewModels.OrganizationViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers {
    [ServiceFilter(typeof(UserFilter))]
    //[Authorize(Policy = "participant")]
    public class OrganizationController : Controller {

		#region Fields
		private readonly IOrganizationRepository _orgRepository;
        private readonly IUserRepository _userRepo;
		#endregion

		#region Constructors
		public OrganizationController(IOrganizationRepository orgRepository, IUserRepository userRepo) {
			_orgRepository = orgRepository;
            _userRepo = userRepo;
		}
		#endregion

		#region Methods
		[Route("Organizations")]
		public IActionResult Index(GUser user, string query = null) {
			// return filtered list with name & location of organisations

            IndexViewModel vm = new IndexViewModel();

		    IEnumerable<Organization> list = _orgRepository.GetByDomain(MailHelper.GetMailDomain(user.Email));
			//IEnumerable<Organization> list = _orgRepository.GetAll().Where(o => o.Domain == MailHelper.GetMailDomain(user.Email));
            if (query != null)
                list = list.Where(o => (o.Name.Contains(query) || o.Location.Contains(query)));

		    vm.Organizations = list;

			return View(vm);
		}

		[HttpPost]
		[Route("Organization/Register")]
		public IActionResult Register(GUser user, int id) {
			// register user with organization

			Organization org = _orgRepository.GetBy(id);

			if (MailHelper.GetMailDomain(user.Email) == org.Domain) {
				org.Register(user);
				return RedirectToAction("Index", "GroupManageController");
			}

			ViewData["Message"] = "Error: Wrong mail address";
			return View();
		}
		#endregion

	}
}
