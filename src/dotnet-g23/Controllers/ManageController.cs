using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers
{
	public class ManageController : Controller
	{
		// GET: /manage/
		public IActionResult Index()
		{
			// show list of open groups
			return View("Index");
		}

		public IActionResult Register(string name, Participant user) {
			// find group, check if user isn't registered and register user with group

			// redirect to group
			return View();
		}

		public IActionResult Create(string name, int type, Participant user)
		{
			// validate name, make new group and register user

			// check if groupname unique and not empty

			//GBOrganization org = GBOrganization.RegisterGroup(name);
			//org.RegisterUser(user);

			//notify lector
			return View("Create");
		}


		public IActionResult Invite(string[] addresses)
		{
			foreach (string address in addresses)
			{
				//validate mail address
				//invite mail address
			}

			//notify lector
			return View();
		}

	}
}
