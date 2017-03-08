using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using dotnet_g23.Filters;
using dotnet_g23.Models.Domain.Repositories;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.ViewModels.MotivationViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_g23.Controllers {
    [Authorize]
    [ServiceFilter(typeof(ParticipantFilter))]
    public class MotivationController : Controller {
        #region Fields
        private readonly IGroupRepository _groupRepository;
        private Motivation mot;
        #endregion

        public MotivationController(IGroupRepository groupRepository) {
            _groupRepository = groupRepository;
        }

        [Authorize(Policy = "participant")]
        [Route("Motivations/{id}")]
        public IActionResult Index(Participant participant, String motivation) {
            IndexViewModel vm = new IndexViewModel();

            Group group = participant.Group;
            vm.SubscribedGroup = group;

            mot = new Motivation(motivation);

            vm.GroupMotivation = mot;

            return View(vm);
        }

        [Authorize(Policy = "participant")]
        [HttpPost]
        [Route("Motivations/{id}/Submit")]
        public IActionResult RegisterMotivation(Participant participant, string submit) {
            RegisterViewModel vm = new RegisterViewModel();

            //vm.GroupMotivation = participant.Group.Motivation;
            vm.GroupMotivation = mot;

            if(submit == "Submit") {
                participant.Group.Motivation = mot;
                _groupRepository.SaveChanges();
                RedirectToAction("Show", "Group");
            }
            else {
                RedirectToAction("Index", "Motivation");
            }

            return View(vm);
        }

        [Authorize(Policy = "lector")]
        [ServiceFilter(typeof(LectorFilter))]
        [HttpGet]
        [Route("Motivations/Check")]
        public IActionResult CheckMotivation(Lector lector, bool approved) {
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
