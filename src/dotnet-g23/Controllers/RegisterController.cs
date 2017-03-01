using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Data.Repositories;
using dotnet_g23.Helpers;
using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers {
	[Authorize]
	public class RegisterController : Controller {

		#region Fields
		private readonly IUserRepository _userRepository;
		private readonly IOrganizationRepository _orgRepository;
		private readonly UserManager<ApplicationUser> _userManager;
		#endregion

		#region Constructors
		public RegisterController(IUserRepository userRepository, IOrganizationRepository orgRepository, UserManager<ApplicationUser> userManager) {
			_userRepository = userRepository;
			_orgRepository = orgRepository;
			_userManager = userManager;
		}
		#endregion

		#region Methods
		[Route("organizations")]
		public IActionResult Index(string query = null) {
			// return filtered list with name & location of GB organisations

			IEnumerable<Organization> list = _orgRepository.GetAll();
			if (query != null)
				list = list.Where(o => (o.Name.IndexOf(query) > -1 || o.Location.IndexOf(query) > -1));

			ViewData["organizations"] = list;
			return View();
		}

		[HttpPost]
		public IActionResult Register(string orgname) {
			// validate & register user with org or throw error

			Organization org = _orgRepository.GetByName(orgname);
			var user = _userManager.FindByNameAsync(User.Identity.Name);

			/*if (MailHelper.VerifyMailAddress(user.Result.Email, org.Domain)) {
				org.Participants.Add(new Participant(org));
				return RedirectToAction("Index", "GroupManageController");
			}*/

			ViewData["Message"] = "Error: Wrong mail address";
			return View();

		}
		#endregion

	}
}
