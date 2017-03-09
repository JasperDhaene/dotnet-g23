using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using dotnet_g23.Filters;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.State;
using dotnet_g23.Models.ViewModels.MotivationViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_g23.Controllers {
    [Authorize]
    [ServiceFilter(typeof(ParticipantFilter))]
    public class MotivationController : Controller {
        #region Fields
        private readonly IGroupRepository _groupRepository;
        #endregion

        public MotivationController(IGroupRepository groupRepository) {
            _groupRepository = groupRepository;
        }

        // GET /Motivations/{id}
        [Authorize(Policy = "participant")]
        [Route("Motivations/{id}")]
        public IActionResult Show(Participant participant, int id) {
            IndexViewModel vm = new IndexViewModel();

            Group group = _groupRepository.GetBy(id);


            if (!(group.Context.CurrentState is InitialState))
                return RedirectToAction("Show", new { id = group.GroupId });

            vm.Group = group;
            vm.Motivation = @group.Motivation ?? new Motivation();

            return View(vm);
        }

        // POST /Motivations/{id}
        [Authorize(Policy = "participant")]
        [HttpPost]
        [Route("Motivations/{id}")]
        public IActionResult Update(Participant participant, int id, Motivation motivation)
        {
            Group group = _groupRepository.GetBy(id);

            if (!(group.Context.CurrentState is InitialState))
                return RedirectToAction("Show", new { id = group.GroupId });

            try
            {
                group.Motivation = motivation;
                _groupRepository.SaveChanges();
            }
            catch (ArgumentException e)
            {
                TempData["message"] = e.Message;
                return RedirectToAction("Show", new { id = group.GroupId });

            }

            // Save
            if (Request.Form.ContainsKey("update"))
            {
                TempData["message"] = "Uw motivatie werd opgeslaan.";
                return RedirectToAction("Show", "Group", new { id = group.GroupId });
            }

            // Submit
            group.Context.NextState();
            _groupRepository.SaveChanges();
            TempData["message"] = "Uw motivatie werd doorgestuurd naar de begeleidende lector.";
            return RedirectToAction("Show", "Group", new { id = group.GroupId });
        }

        // GET /Motivations
        [Authorize(Policy = "lector")]
        [ServiceFilter(typeof(LectorFilter))]
        [HttpGet]
        [Route("Motivations")]
        public IActionResult Check(Lector lector, bool approved) {
            CheckViewModel vm = new CheckViewModel();

            Group g = _groupRepository.GetByName(lector.Group.Name);

            if (!g.Motivation.Approved) {
                vm.UnnaprovedMotivation = g.Motivation;
                if (approved) {
                    g.Motivation.Approved = approved;
                    vm.ApprovedMotivation = vm.UnnaprovedMotivation;
                    vm.UnnaprovedMotivation = null;
                    _groupRepository.SaveChanges();
                }
            }
            else {
                vm.ApprovedMotivation = g.Motivation;
            }

            return View(vm);
        }
    }
}
