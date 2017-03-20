using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Data.Repositories;
using dotnet_g23.Filters;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.OrganizationViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers {
    [Authorize]
    [ServiceFilter(typeof(UserFilter))]
    public class OrganizationController : Controller {

        #region Fields
        private readonly IOrganizationRepository _orgRepository;
        private readonly IGroupRepository _groupRepositroy;
        private readonly IPostRepository _postRepository;
        #endregion

        #region Constructors
        public OrganizationController(IOrganizationRepository orgRepository, IGroupRepository groupRepository, IPostRepository postRepository) {
            _orgRepository = orgRepository;
            _groupRepositroy = groupRepository;
            _postRepository = postRepository;
        }
        #endregion

        #region Methods
        // GET /Organizations
        [Route("Organizations")]
        [ServiceFilter(typeof(ParticipantFilter))]
        public IActionResult Index(GUser user, Participant participant, String query = null) {
            // Return filtered list with name & location of organisations

            IndexViewModel vm = new IndexViewModel() {
                SubscribedOrganization = participant?.Organization,
                Organizations = query == null ? _orgRepository.GetAll() : _orgRepository.GetByKeyword(query)
            };
            return View(vm);
        }

        // POST /Organizations/Register
        [HttpPost]
        [Route("Organizations/Register")]
        public IActionResult Register(GUser user, int organizationId) {
            // Register user with organization

            Organization organization = _orgRepository.GetBy(organizationId);
            try
            {
                organization.Register(user);
                _orgRepository.SaveChanges();
            }
            catch (GoedBezigException e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("Index", "Organizations");
            }
            TempData["success"] = $"U bent geregistreerd bij organisatie '{organization.Name}'";
            return RedirectToAction("Index", "Groups");
        }

        [Route("Organizations/{id}")]
        public IActionResult Show(Participant participant, int id) {
            //Get Organization with id from Repo

            Organization org = _orgRepository.GetBy(id);

            ShowViewModel vm = new ShowViewModel();
            //Show all Groups, linked with organization
            vm.Groups = _groupRepositroy.GetByOrganization(org);
            vm.Posts = _postRepository.GetByOrganization(org);
            vm.Organization = org;

            return View(vm);
        }
        #endregion

    }
}