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

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_g23.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(ParticipantFilter))]
    public class LabelController : Controller
    {
        #region fields
        private readonly ICompanyRepository _companyRepository;
        private readonly IContactRepository _contactRepository;
        #endregion

        #region Constructor
        public LabelController(ICompanyRepository compRepo, IContactRepository contactRepo) {
            _companyRepository = compRepo;
            _contactRepository = contactRepo;
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

        [Route("Organizations/Register")]
        public IActionResult Register(GUser user, Group group, int companyId) 
        {
            Company company = _companyRepository.GetBy(companyId);

            return View();
        }

        public IActionResult ShowDashBoard(Participant participant, int id) {
            // Show Company dashboard

            ShowViewModel vm = new ShowViewModel();
            vm.Company = _companyRepository.GetBy(id);
            vm.Contacts = _contactRepository.GetByCompany(vm.Company);

            return View(vm);
        }

    }
}
