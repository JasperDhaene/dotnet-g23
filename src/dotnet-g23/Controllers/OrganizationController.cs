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
        #endregion

        #region Constructors
        public OrganizationController(IOrganizationRepository orgRepository) {
            _orgRepository = orgRepository;
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
            try {
                organization.Register(user);
                _orgRepository.SaveChanges();
                TempData["info"] = $"U bent geregistreerd bij organisatie '{organization.Name}'";
                return RedirectToAction("Index", "Groups");
            }
            catch (Exception e) {
                TempData["error"] = e.Message;
                return RedirectToAction("Index", "Organizations");
            }
        }
        #endregion

    }
}