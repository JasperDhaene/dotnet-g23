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
    public class ActionController : Controller
    {

        #region Fields
		private readonly IParticipantRepository _participantRepository;

		#endregion

        #region Constructors
		public ActionController(IParticipantRepository participantRepository) {
		    _participantRepository = participantRepository;
		}
		#endregion

		#region Methods
        // GET /Groups/{id}/Action
        [Route("Groups/{id}/Action")]
        public IActionResult New(Participant participant)
        {
            return View();
        }
        #endregion
    }
}
