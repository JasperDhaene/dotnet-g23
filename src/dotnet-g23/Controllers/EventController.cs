using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Data.Repositories;
using dotnet_g23.Filters;
using dotnet_g23.Models;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.Domain.State;
using dotnet_g23.Models.ViewModels.GroupViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers
{
    [Authorize(Policy = "participant")]
	[ServiceFilter(typeof(ParticipantFilter))]
	public class EventController : Controller
	{

		#region Fields
		private readonly IParticipantRepository _participantRepository;

		#endregion

		#region Constructors
		public EventController(IParticipantRepository participantRepository) 
            {
		    _participantRepository = participantRepository;
		    }
		#endregion

		#region Methods
        // GET /Groups
		[Route("Events")]
		public IActionResult Index(Participant participant)
		{
            // Return list with invites and open organizations

		    IndexViewModel vm = new IndexViewModel
		    {
                Organization = participant.Organization,
		        SubscribedGroup = participant.Group,
            };

		    return View(vm);
		}

        // GET /Groups/Create
        [Route("Events/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST /Groups/Create
        [HttpPost]
	    [Route("Events/Create")]
	    public IActionResult Create(Participant participant, String name, Boolean closed = false)
	    {
	        // Create new group
	        Organization organization = participant.Organization;
	        try
	        {
	            Group group = organization.CreateGroup(participant, name, closed);

	            TempData["success"] = $"De groep '{name}' is aangemaakt";
                return RedirectToAction("Invite", new { id = group.GroupId });
            }
	        catch (GoedBezigException e)
	        {
	            TempData["error"] = e.Message;
	            return View("Create");
	        }
        }
        #endregion
    }
}

	    

