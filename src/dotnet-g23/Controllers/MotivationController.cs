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
        #endregion

        public MotivationController(IGroupRepository groupRepository) {
            _groupRepository = groupRepository;
        }

        [Authorize(Policy = "participant")]
        [Route("Groups/{id}/Motivations/Edit")]
        public IActionResult Index(Participant participant) {
            IndexViewModel vm = new IndexViewModel();
            Group group = participant.Group;
            vm.SubscribedGroup = group;
            return View(vm);
        }

        [Authorize(Policy = "participant")]
        [HttpPost]
        [Route("Groups/{id}/Motivations/Submit")]
        public IActionResult RegisterMotivation(Participant participant, String motivation) {
            RegisterViewModel vm = new RegisterViewModel();

            Motivation mot = new Motivation(motivation);
            participant.Group.Motivation = mot;

            vm.GroupMotivation = mot;

            return View(vm);
        }

        [Authorize(Policy = "lector")]
        [HttpGet]
        [Route("Motivations/Check")]
        public IActionResult CheckMotivation(Lector lector, bool approved) {
            CheckViewModel vm = new CheckViewModel();

            Group g = _groupRepository.GetByName(lector.Group.Name);

            if (!g.Motivation.Approved) {
                vm.UnnaprovedMotivation = g.Motivation;
                if (approved) {
                    vm.ApprovedMotivation = vm.UnnaprovedMotivation;
                    vm.UnnaprovedMotivation = null;
                }
            }
            else {
                vm.ApprovedMotivation = g.Motivation;
            }

            return View(vm);
        }
    }
}
