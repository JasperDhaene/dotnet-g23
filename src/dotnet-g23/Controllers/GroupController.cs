using System.Linq;
using dotnet_g23.Filters;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.GroupViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers
{
    [Authorize(Policy = "participant")]
    [ServiceFilter(typeof(ParticipantFilter))]
    public class GroupController : Controller
    {
        #region Constructors

        public GroupController(IGroupRepository groupRepository,
            IParticipantRepository participantRepository,
            IInvitationRepository invitationRepository,
            ILabelRepository labelRepository,
            IPostRepository postRepository,
            IHostingEnvironment hostingEnvironment)
        {
            _groupRepository = groupRepository;
            _participantRepository = participantRepository;
            _invitationRepository = invitationRepository;
            _labelRepository = labelRepository;
            _postRepository = postRepository;

            _hostingEnvironment = hostingEnvironment;
        }

        #endregion

        #region Fields

        private readonly IGroupRepository _groupRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IInvitationRepository _invitationRepository;
        private readonly ILabelRepository _labelRepository;
        private readonly IPostRepository _postRepository;

        private readonly IHostingEnvironment _hostingEnvironment;

        #endregion

        #region Methods

        // GET /Groups
        [Route("Groups")]
        public IActionResult Index(Participant participant)
        {
            // Return list with invites and open organizations

            var vm = new IndexViewModel
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
        public IActionResult Create(Participant participant, string name, bool closed = false)
        {
            // Create new group
            var organization = participant.Organization;
            try
            {
                var group = organization.CreateGroup(participant, name, closed);
                _groupRepository.SaveChanges();

                TempData["success"] = $"De groep '{name}' is aangemaakt";
                return RedirectToAction("Invite", new {id = group.GroupId});
            }
            catch (GoedBezigException e)
            {
                TempData["error"] = e.Message;
                return View("Create");
            }
        }

        // GET /Dashboard
        [Route("Dashboard")]
        public IActionResult Dashboard(Participant participant, int id)
        {
            // Show personal dashboard


            if (participant.Group == null)
            {
                TempData["error"] = "U bent nog niet geregistreerd bij een groep.";
                return RedirectToAction("Index");
            }

            var group = _groupRepository.GetBy(participant.Group.GroupId);

            var vm = new ShowViewModel
            {
                Group = group,
                Participants = _participantRepository.GetByGroup(group),
                Invitations = _invitationRepository.GetByGroup(group)
            };

            return View(vm);
        }

        // GET /Groups/:id
        [Route("Groups/{id}")]
        public IActionResult Show(Participant participant, int id)
        {
            // Show group

            var group = _groupRepository.GetBy(id);

            var vm = new ShowViewModel
            {
                Group = group,
                Participants = _participantRepository.GetByGroup(group),
                Invitations = _invitationRepository.GetByGroup(group)
            };

            return View(vm);
        }

        // POST /Groups/{id}/Register
        [HttpPost]
        [Route("Groups/{id}/Register")]
        public IActionResult Register(Participant participant, int id)
        {
            // Register user with group

            var group = _groupRepository.GetBy(id);
            try
            {
                group.Register(participant);
                _invitationRepository.Destroy(participant, group);

                _groupRepository.SaveChanges();
            }
            catch (GoedBezigException e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("Index");
            }
            TempData["success"] = $"U bent geregistreerd bij groep '{group.Name}'";
            return RedirectToAction("Dashboard");
        }

        // GET /Groups/{id}/Invite
        [Route("Groups/{id}/Invite")]
        public IActionResult Invite(Participant participant, int id)
        {
            // Show invite form

            var group = _groupRepository.GetBy(id);
            return View(group);
        }

        // POST /Groups/{id}/Invite
        [HttpPost]
        [Route("Groups/{id}/Invite")]
        public IActionResult Invite(Participant participant, int id, string address)
        {
            // Invite user to group

            var group = _groupRepository.GetBy(id);
            var invitee = _participantRepository.GetByEmail(address);
            try
            {
                group.Invite(invitee);
                _groupRepository.SaveChanges();
            }
            catch (GoedBezigException e)
            {
                TempData["error"] = e.Message;
                return View("Invite", group);
            }
            TempData["success"] = $"Gebruiker '{address}' werd uitgenodigd tot de groep";
            return View("Invite", group);
        }

        // GET /Groups/{id}/Announce
        [Route("Groups/{id}/Announce")]
        public IActionResult Announce(Participant participant, int id)
        {
            // Show announce form

            var label = _labelRepository.GetByGroup(id);

            var vm = new AnnounceViewModel
            {
                Label = label,
                Message = ""
            };

            return View(vm);
        }

        // POST /Groups/{id}/Announce
        [HttpPost]
        [Route("Groups/{id}/Announce")]
        public IActionResult Announce(Participant participant, int id, string message)
        {
            // Announce label on social media

            var group = _groupRepository.GetBy(id);
            try
            {
                var post = group.Announce(message);

                _postRepository.Add(post);
                _postRepository.SaveChanges();
            }
            catch (GoedBezigException e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("Announce", new {id = group.GroupId});
            }
            TempData["success"] = "Bericht werd gepubliceerd. ";
            TempData["linkText"] = "Toon bericht";
            TempData["linkController"] = "Organization";
            TempData["linkAction"] = "Show";
            TempData["linkId"] = participant.Group.Organization.OrganizationId;

            return RedirectToAction("Dashboard");
        }

        #endregion
    }
}