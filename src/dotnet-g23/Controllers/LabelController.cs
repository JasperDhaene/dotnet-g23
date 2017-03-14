using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_g23.Filters;
using Microsoft.AspNetCore.Authorization;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.Domain;

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


    }
}
