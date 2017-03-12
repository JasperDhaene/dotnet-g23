using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Data.Repositories;
using dotnet_g23.Filters;
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
		private readonly IParticipantRepository _participantRepository;
	    private readonly IInvitationRepository _invitationRepository;
		#endregion

		#region Constructors
		public GroupController(IGroupRepository groupRepository, IParticipantRepository participantRepository, IInvitationRepository invitationRepository) {
			_groupRepository = groupRepository;
		    _participantRepository = participantRepository;
		    _invitationRepository = invitationRepository;
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
                Organization = participant.Organization,
		        SubscribedGroup = participant.Group,
		        InvitedGroups = _invitationRepository.GetByParticipant(participant).Select(i => i.Group),
                OpenGroups = _groupRepository.GetByOrganization(participant.Organization).Where(g => !g.Closed)
            };

		    return View(vm);
		}

        // GET /Groups/Create
        [Route("Groups/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST /Groups/Create
        [HttpPost]
        [Route("Groups/Create")]
        public IActionResult Create(Participant participant, String name, Boolean closed)
        {
            // Create new group

            if (participant.Group != null)
            {
                TempData["error"] = "U bent reeds ingeschreven in een groep.";
                return RedirectToAction("Index");
            }

            try
            {
                Group group = participant.Organization.CreateGroup(participant, name);
                _groupRepository.SaveChanges();
                return RedirectToAction("Invite", new { id = group.GroupId });
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return View("Create");
            }
        }

        // GET /Groups/:id
        [Route("Groups/{id}")]
        public IActionResult Show(Participant participant, int id)
        {
            // Show group dashboard

            ShowViewModel vm = new ShowViewModel();
            vm.Group = _groupRepository.GetBy(id);
            vm.Participants = _participantRepository.GetByGroup(vm.Group);
            vm.Invitations = _invitationRepository.GetByGroup(vm.Group);

            return View(vm);
        }

        // POST /Groups/{id}/Register
        [HttpPost]
		[Route("Groups/{id}/Register")]
		public IActionResult Register(Participant participant, int id) {
			// Register user with group

            try
            {
                Group group = _groupRepository.GetBy(id);
                group.Register(participant);

                _invitationRepository.Destroy(participant, group);

                _groupRepository.SaveChanges();
                TempData["info"] = $"U bent geregistreerd bij groep '{group.Name}'";
                return RedirectToAction("Show", new { id = group.GroupId });
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("Index");
            }
		}

        // GET /Groups/{id}/Invite
	    [Route("Groups/{id}/Invite")]
	    public IActionResult Invite(Participant participant, int id)
	    {
            // Show invite form

            Group group = _groupRepository.GetBy(id);

            return View("Invite", group);
	    }

        // POST /Groups/{id}/Invite
		[HttpPost]
		[Route("Groups/{id}/Invite")]
		public IActionResult Invite(Participant participant, int id, String address)
		{
            // Invite user to group

            Group group = _groupRepository.GetBy(id);
            try
		    {
		        Participant invitee = _participantRepository.GetByEmail(address);

		        if (invitee == null)
		        {
		            TempData["error"] = $"Gebruiker '{address}' niet gevonden.";
		            return View("Invite", group);
		        }
		        group.Invite(invitee);
		        // TODO: Invite lector
		        _groupRepository.SaveChanges();
		        TempData["info"] = $"Gebruiker '{address}' werd uitgenodigd tot de groep.";
		        return View("Invite", group);
		    }
		    catch (Exception e)
            {
                TempData["info"] = e.Message;
                return View("Invite", group);
            }
		}
		#endregion

	}
}
