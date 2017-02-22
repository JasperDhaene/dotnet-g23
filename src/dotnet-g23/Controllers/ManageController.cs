using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Data.Repositories;
using dotnet_g23.Helpers;
using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers
{
	public class ManageController : Controller
	{

		private GADUser _user;
		private readonly IGADUserRepository _userRepository;
		private readonly IGADOrganizationRepository _orgRepository;

		public ManageController(IGADUserRepository userRepository, IGADOrganizationRepository orgRepository) {
			_userRepository = userRepository;
			_orgRepository = orgRepository;
		}

		[Route("groups")]
		public IActionResult Index()
		{
			// show list of open groups
			GADOrganization[] orgList = _orgRepository.GetAll().Where(o => o.OrganizationRole.ToString() == "GBOrganization").ToArray();
			Group[] list = {};

			//foreach (GADOrganization org in orgList)
				//foreach (Group group in org.Groups)
					//if (!group.GetIsClosed())
						//list[list.Length-1] = group;

			return View("Index",list);
		}

		[HttpPost]
		[Route("groups/register")]
		public IActionResult Register(string name) {
			// find group, check if user isn't registered and register user with group

			// redirect to group detail
			return View();
		}

		[HttpPost]
		[Route("groups/create")]
		public IActionResult Create(string name = null, bool closed = false)
		{
			// validate name, make new group and register user

			// show error
			if (name == null)
			{
				ViewData["Message"] = "Error: Wrong name";
				return View();
			}


			// check if groupname unique and not empty
			//GBOrganization org = GBOrganization.CreateGroup(name);
			//org.RegisterUser(_user);

			// notify lector
			return View("Create");
		}

		[HttpPost]
		[Route("groups/invite")]
		public IActionResult Invite(string[] addresses = null)
		{

			if (addresses != null)
			{
				foreach (string address in addresses)
				{
					if (MailHelper.VerifyMailAddress(address))
					{
						// invite mail address
					}
				}
			}

			// notify lector
			return View();
		}

	}
}
