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

namespace dotnet_g23.Controllers
{
	[Authorize]
	public class GroupManageController : Controller
	{

		#region Fields
		private readonly IUserRepository _userRepository;
		private readonly IOrganizationRepository _orgRepository;
		private readonly UserManager<ApplicationUser> _userManager;
		#endregion

		#region Constructors
		public GroupManageController(IUserRepository userRepository, IOrganizationRepository orgRepository, UserManager<ApplicationUser> userManager) {
			_userRepository = userRepository;
			_orgRepository = orgRepository;
			_userManager = userManager;
		}
		#endregion

		#region Methods
		[Route("groups")]
		public IActionResult Index()
		{

			// show list of open groups
			IEnumerable<Organization> orgList = _orgRepository.GetAll();
			IEnumerable<Group> list = new List<Group>();

			foreach (Organization org in orgList)
				foreach (Group group in org.Groups)
					list.Append(group);

			ViewData["groups"] = list;
			return View();

		}

		[HttpPost]
		public IActionResult Register(string name) {
			// find group, check if user isn't registered and register user with group

			Group group;

			IEnumerable<Organization> orgList = _orgRepository.GetAll();
			foreach (Organization org in orgList)
				foreach (Group gr in org.Groups)
					if (gr.Name == name)
						group = gr;

			var authuser = _userManager.FindByNameAsync(User.Identity.Name);
			GUser user = _userRepository.GetByEmail(authuser.Result.Email);

			/*if (user.Group != null)
			{
				group.Participants.Add(user);
				user.Group = group;
				ViewData["Message"] = "Error: already registered";
				return View();
			}*/


			// redirect to group detail
			return RedirectToAction("Index", "GroupManageController");
		}

		[HttpPost]
		//[Route("groups/create")]
		public IActionResult Create(string name = null, bool closed = false)
		{
			// validate name, make new group and register user

			if (name == null)
			{
				ViewData["Message"] = "Error: Wrong name";
				return View();
			}

			// check if groupname unique and not empty
			var authuser = _userManager.FindByNameAsync(User.Identity.Name);
			GUser user = _userRepository.GetByEmail(authuser.Result.Email);

			/*Organization org = user.Organization;
			Group group = new Group(name);
			group.Participants.Add(user);
			org.Groups.Add(group);*/

			// notify lector
			//_user.Lector.Notify();
			return View();
		}

		[HttpPost]
		//[Route("groups/invite")]
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
			//_user.Lector.Notify();
			return View();
		}
		#endregion

	}
}
