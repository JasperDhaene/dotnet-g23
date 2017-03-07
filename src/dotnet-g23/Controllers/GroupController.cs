using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Data.Repositories;
using dotnet_g23.Filters;
using dotnet_g23.Helpers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.GroupViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers
{
    [Authorize(Policy = "participant")]
	[ServiceFilter(typeof(ParticipantFilter))]
	public class GroupController : Controller
	{

		#region Fields
		private readonly IGroupRepository _groupRepository;
		#endregion

		#region Constructors
		public GroupController(IGroupRepository groupRepository) {
			_groupRepository = groupRepository;
		}
		#endregion

		#region Methods
        // GET /Groups
		[Route("Groups")]
		public IActionResult Index(Participant participant)
		{
            // Return list with invites and open organizations

		    IndexViewModel vm = new IndexViewModel
		    {
		        SubscribedGroup = participant.Group,
		        InvitedGroups = participant.User.Invitations?.Select(n => n.Group),
		        OpenGroups = participant.Organization.Groups?.Where(g => !g.Closed)
		    };

		    return View(vm);
		}

        // POST /Groups/Register/{id}
		[HttpPost]
		[Route("Groups/Register/{id}")]
		public IActionResult Register(Participant participant, int id) {
			// Register user with group

			if (participant.Group != null)
			{
				TempData["Message"] = "U bent reeds geregistreerd bij een groep.";
				return RedirectToAction("Index", "GroupController");
			}

			Group group = _groupRepository.GetBy(id);
			group.Register(participant);
		    _groupRepository.SaveChanges();

			return RedirectToAction("Show", "Groups");
		}

        // GET /Groups/:id
	    [Route("Group/{id}")]
	    public IActionResult Show(Participant participant, int id)
	    {
            // Show group dashboard

	        Group group = _groupRepository.GetBy(id);

	        return View(group);
	    }

        // GET /Groups/Create
		[Route("Group/Create")]
		public IActionResult Create() {
			return View();
		}

        // POST /Groups/Create
		[HttpPost]
		[Route("Group/Create")]
		public IActionResult Create(Participant participant, String name, Boolean closed)
		{
			// Create new group

            if (participant.Group != null)
                return RedirectToAction("Index", "Groups");

		    try
		    {
		        participant.Organization.CreateGroup(participant, name);
                _groupRepository.SaveChanges();
		        //return RedirectToAction("Invite", "Groups");
		        return RedirectToAction("Index", "Groups");
		    }
		    catch (ArgumentException e)
		    {
		        TempData["message"] = e.Message;
		        return View();
		    }
		}

        // GET /Groups/Invite
	    [Route("Groups/Invite")]
	    public IActionResult Invite(Participant participant)
	    {
	        return View();
	    }

        // POST /Groups/Invite
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
				return RedirectToAction("RegisterMotivation", "Motivations");
			}

			//return View();
			return RedirectToAction("Index", "GroupManageController");
		}
		#endregion

	}
}
