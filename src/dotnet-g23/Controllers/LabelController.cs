using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_g23.Filters;
using dotnet_g23.Models;
using Microsoft.AspNetCore.Authorization;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.ViewModels.LabelViewModels;
using dotnet_g23.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_g23.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(ParticipantFilter))]
    public class LabelController : Controller
    {
        #region Fields
        private readonly ICompanyRepository _companyRepository;
        private readonly IGroupRepository _groupRepository;
        #endregion

        #region Constructor
        public LabelController(ICompanyRepository companyRepository, IGroupRepository groupRepository) {
            _companyRepository = companyRepository;
            _groupRepository = groupRepository;
        }
        #endregion

        [Route("Companies")]
        public IActionResult Index(GUser user, String query = null)
        {
            // Show companies
            IndexViewModel vm = new IndexViewModel() {
                Companies = query == null ? _companyRepository.GetAll() : _companyRepository.GetByKeyword(query)
            };
            return View(vm);
        }

        [Route("Companies/{id}")]
        public IActionResult Show(Participant participant, int id)
        {
            Group group = _groupRepository.GetBy(participant.Group.GroupId);

            // Show company contacts

            ShowViewModel vm = new ShowViewModel();

            vm.Company = _companyRepository.GetBy(id);
            vm.Contacts = vm.Company.Contacts;
            vm.Group = group;
            vm.Label = group.Label;

            return View(vm);
        }

        [HttpPost]
        [Route("Companies/{id}")]
        public IActionResult Send(Participant participant, int id, int[] contactIds)
        {
            // Grant label to company

            Company company = _companyRepository.GetBy(id);
            Group group = participant.Group;
            
            try
            {
                group.Grant(company);
                _companyRepository.SaveChanges();

                AuthMessageSender sender = new AuthMessageSender();

                foreach (var cId in contactIds)
                {
                    Contact contact = company.Contacts.First(co => co.ContactId == cId);

                    sender.SendEmailAsync(contact.Company.Name, contact.Email,
                        contact.Company.Name, contact.Company.Description);
                }

                
            }
            catch (GoedBezigException e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("Show", new { id = id });
            }
            TempData["success"] = $"Het label werd toegekend aan de organisatie.";
            return RedirectToAction("Dashboard", "Group");
        }

    }
}
