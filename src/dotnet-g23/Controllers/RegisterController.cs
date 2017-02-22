using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Helpers;
using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers {
	public class RegisterController : Controller {
		// GET: /register/
		public IActionResult Index(string query = null) {
			// return filtered list with name & location of GB organisations
			GBOrganization[] list = GADOrganizationRepository.getAll().Where(o => o.OrganizationRole.ToString() == "GBOrganization" );
			if (query != null)
				list = list.Where(o => (o.Name.IndexOf(query) > -1 | o.Location.IndexOf(query) > -1));
			return View("Index");
		}

		public IActionResult Register(GBOrganization org, GADUser user) {

			// validate & register user or throw error
			if (MailHelper.VerifyMailAddress(user.Email)) { 
				org.RegisterParticipant(user);
				// redirect to group
				return View();
			}
			else {
				//show error
				return View();
			}
		}

	}
}
