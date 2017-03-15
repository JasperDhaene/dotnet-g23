using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_g23.Filters;
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
        #region fields
        private readonly ICompanyRepository _companyRepository;
        #endregion

        #region Constructor
        public LabelController(ICompanyRepository compRepo) {
            _companyRepository = compRepo;
        }
        #endregion

        [Route("Companies")]
        public IActionResult Index(GUser user, Group group, String query = null)
        {
            IndexViewModel vm = new IndexViewModel() {
                ChosenCompany = group?.Company,
                Companies = query == null ? _companyRepository.GetAll() : _companyRepository.GetByKeyword(query)
            };
            return View(vm);
        }

        [HttpPost]
        [Route("Companies/Register")]
        public IActionResult Register(GUser user, Group group, int companyId) 
        {
            Company company = _companyRepository.GetBy(companyId);

            try {
                company.Register(group);
                _companyRepository.SaveChanges();
                TempData["info"] = $"U bent als groep geregistreerd bij '{group.Name}'";
                return RedirectToAction("ShowDashBoard", new { id = @company.companyId });
            }
            catch (Exception e) {
                TempData["error"] = e.Message;
                return RedirectToAction("Index", "LabelController");
            }
        }

        [Route("Companies/{id}")]
        public IActionResult ShowDashBoard(Participant participant, int id) {
            // Show Company dashboard

            ShowViewModel vm = new ShowViewModel();

            vm.Company = _companyRepository.GetBy(id);
            vm.Contacts = vm.Company.Contacts;

            return View(vm);
        }

        public IActionResult Send(Participant participant, Company company, int contactId) {
            Contact contact = company.Contacts.First(co => co.ContactId == contactId);

            AuthMessageSender sender = new AuthMessageSender();
            sender.SendEmailAsync(contact.FirstName + " " + contact.LastName, contact.Email, contact.Company.Name, contact.Company.Description);

            return RedirectToAction("Index", "Labels");
        }

    }
}
