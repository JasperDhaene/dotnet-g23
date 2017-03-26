using System.Linq;
using dotnet_g23.Filters;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.ActionViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace dotnet_g23.Controllers
{
    [Authorize(Policy = "participant")]
    [ServiceFilter(typeof(ParticipantFilter))]
    public class ActionController : Controller
    {
        #region Constructors

        public ActionController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        #endregion

        #region Fields

        private readonly IGroupRepository _groupRepository;

        #endregion

        #region Methods

        [Route("Groups/{id}/Action")]
        public IActionResult Create(Participant participant, int id)
        {
            var vm = new CreateViewModel();

            var group = _groupRepository.GetBy(id);

            vm.Group = group;
            vm.Action = new Action();

            return View();
        }

        // GET /Groups/{id}/Action
        [HttpPost]
        [Route("Groups/{gid}/Action")]
        public IActionResult Update(Participant participant, int gid, Action action)
        {
            var group = _groupRepository.GetBy(gid);

            string createEvent = Request.Form["action.createEvent"];

            try
            {
                if (!ModelState.IsValid)
                    throw new GoedBezigException(
                        ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage)).Join());

                if (createEvent == "off")
                    group.SetupAction(action.Title, action.Description);
                else
                    group.SetupAction(action.Title, action.Description, action.Date);

                _groupRepository.SaveChanges();

                TempData["success"] = $"De actie '{action.Title}' is aangemaakt";
                return RedirectToAction("Show", "Group", new {id = group.GroupId});
            }
            catch (GoedBezigException e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("Update", "Action", new {id = group.GroupId});
            }
        }

        #endregion
    }
}