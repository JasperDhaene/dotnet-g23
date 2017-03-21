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
using dotnet_g23.Models.ViewModels.ActionViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Action = dotnet_g23.Models.Domain.Action;
namespace dotnet_g23.Controllers
{
    [Authorize(Policy = "participant")]
	[ServiceFilter(typeof(ParticipantFilter))]
    public class ActionController : Controller
    {

        #region Fields
		private readonly IParticipantRepository _participantRepository;
        private readonly IGroupRepository _groupRepository;

		#endregion

        #region Constructors
		public ActionController(IParticipantRepository participantRepository,IGroupRepository groupRepository) {
		    _participantRepository = participantRepository;
            _groupRepository = groupRepository;
		}
		#endregion

		#region Methods

        [Authorize(Policy = "participant")]
        [Route("Groups/{id}/Action/New")]
        public IActionResult Create(Participant participant, int id)
        {
            CreateViewModel vm = new CreateViewModel();

            Group group = _groupRepository.GetBy(id);

            vm.Group = group;
            vm.Action = new Action();

            return View();
        }

        // GET /Groups/{id}/Action
        [Authorize(Policy = "participant")]
        [HttpPost]
        [Route("Groups/{gid}/Action/New")]
        public IActionResult Update(Participant participant, int gid, Action action)
        {
            
	        Group group = _groupRepository.GetBy(gid);
	        try
	        {
	            group.setupAction(action.Title,action.Description,action.Date);
                _groupRepository.SaveChanges();

	            TempData["success"] = $"De actie '{action.Title}' is aangemaakt";
                return RedirectToAction("Show","Group", new { id = group.GroupId });
            }
	        catch (GoedBezigException e)
	        {
	            TempData["error"] = e.Message;
	            return View("Action");
	        }
        }
        #endregion
    }
}
