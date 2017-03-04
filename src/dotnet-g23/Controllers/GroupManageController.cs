using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Data.Repositories;
using dotnet_g23.Filters;
using dotnet_g23.Helpers;
using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers
{
    [Authorize(Policy = "participant")]
	[ServiceFilter(typeof(UserFilter))]
	public class GroupManageController : Controller
	{

		#region Fields
		private readonly IGroupRepository _groupRepository;
		#endregion

		#region Constructors
		public GroupManageController(IGroupRepository groupRepository) {
			_groupRepository = groupRepository;
		}
		#endregion

		#region Methods
		[Route("Groups")]
		public IActionResult Index(Participant user)
		{
			// show list of open groups
			IEnumerable<Group> groups = _groupRepository.GetByOrganization(user.Organization).Where(g => !g.Closed);
			ViewData["groups"] = groups;
			return View();
		}

		[HttpPost]
		[Route("Group/Register")]
		public IActionResult Register(Participant user, int id) {
			// register user with group

			if (user.Group != null)
			{
				ViewData["Message"] = "Error: already registered";
				return RedirectToAction("Index", "GroupManageController");
			}

			Group group = _groupRepository.GetBy(id);
			group.Register(user);

			// redirect to group detail
			return RedirectToAction("RegisterMotivation", "MotivationController");
		}


		[Route("Group/Create")]
		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		[Route("Group/Create")]
		public IActionResult Create(Participant user, string name = null, bool closed = false)
		{
			// create new group with organization

			if (name != null)
			{
				user.Organization.CreateGroup(user, name);
				// notify lector
				return RedirectToAction("Invite", "GroupManageController");
			}

			return RedirectToAction("Index", "GroupManageController");
		}

		[HttpPost]
		[Route("Group/Invite")]
		public IActionResult Invite(Participant user, string[] addresses = null)
		{

			// invite new users to group

			if (addresses != null)
			{
				foreach (string address in addresses)
				{
					//Invite(address);
				}
				// notify lector
				return RedirectToAction("RegisterMotivation", "MotivationController");
			}

			//return View();
			return RedirectToAction("Index", "GroupManageController");
		}
		#endregion

	}
}
