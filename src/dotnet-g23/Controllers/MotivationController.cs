using System.Linq;
using dotnet_g23.Filters;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.ViewModels.MotivationViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_g23.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(ParticipantFilter))]
    public class MotivationController : Controller
    {
        #region Fields

        private readonly IGroupRepository _groupRepository;

        #endregion

        public MotivationController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        // GET /Motivations/{id}
        [Authorize(Policy = "participant")]
        [Route("Motivations/{id}")]
        public IActionResult Edit(Participant participant, int id)
        {
            var vm = new ShowViewModel();

            var group = _groupRepository.GetBy(id);

            vm.Group = group;
            vm.Motivation = group.Motivation ?? new Motivation();

            return View(vm);
        }

        // POST /Motivations/{id}
        [Authorize(Policy = "participant")]
        [HttpPost]
        [Route("Motivations/{id}")]
        public IActionResult Update(Participant participant, int id, Motivation motivation)
        {
            // Save or submit motivation

            var group = _groupRepository.GetBy(id);

            try
            {
                if (Request.Form.ContainsKey("submit"))
                {
                    if (!ModelState.IsValid)
                        throw new GoedBezigException(
                            ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage)).Join());

                    group.Save(motivation);
                    group.Submit();

                    TempData["success"] = "Uw motivatie werd verzonden naar de begeleidende lector";
                }
                else
                {
                    group.Save(motivation);
                    TempData["success"] = "Uw motivatie werd opgeslaan";
                }
                _groupRepository.SaveChanges();

                return RedirectToAction("Dashboard", "Group");
            }
            catch (GoedBezigException e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("Edit", new {id = group.GroupId});
            }
        }
    }
}