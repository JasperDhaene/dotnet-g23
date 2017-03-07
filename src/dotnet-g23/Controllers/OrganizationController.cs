using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Data.Repositories;
using dotnet_g23.Filters;
using dotnet_g23.Helpers;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.OrganizationViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g23.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(UserFilter))]
    public class OrganizationController : Controller
    {

		#region Fields
		private readonly IOrganizationRepository _orgRepository;
		#endregion

		#region Constructors
		public OrganizationController(IOrganizationRepository orgRepository)
        {
			_orgRepository = orgRepository;
		}
		#endregion

		#region Methods
        // GET /Organizations
		[Route("Organizations")]
		public IActionResult Index(GUser user, string query = null)
        {
			// Return filtered list with name & location of organisations

            IndexViewModel vm = new IndexViewModel();

		    IEnumerable<Organization> list = _orgRepository.GetByDomain(MailHelper.GetMailDomain(user.Email));
            if (query != null) {
                list = _orgRepository.GetByKeyword(query, MailHelper.GetMailDomain(user.Email));
                if (!list.Any()) {
                    TempData["error"] = $"De gezochte organisatie werd niet gevonden, dit zijn de enige mogelijkheden!";
                    list = _orgRepository.GetByDomain(MailHelper.GetMailDomain(user.Email));
                }
            }

            vm.SubscribedOrganization = (user.UserState as Participant)?.Organization;
            vm.Organizations = list.Where(org => org != vm.SubscribedOrganization);

			return View(vm);
		}

        // POST /Organizations/Register
		[HttpPost]
		[Route("Organizations/Register")]
		public IActionResult Register(GUser user, int organizationId)
        {
			// Register user with organization

		    Organization organization = _orgRepository.GetBy(organizationId);
		    try
		    {
		        organization.Register(user);
		        _orgRepository.SaveChanges();
		        return RedirectToAction("Index", "Groups");
		    }
		    catch (Exception e)
		    {
                TempData["error"] = e.Message;
		        return RedirectToAction("Index", "Organizations");
		    }
		}
		#endregion

	}
}
