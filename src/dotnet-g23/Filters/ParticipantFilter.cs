using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using dotnet_g23.Models.Domain;
using System;
using dotnet_g23.Models.Domain.Repositories;

namespace dotnet_g23.Filters {
    public class ParticipantFilter : ActionFilterAttribute {
        private readonly IUserRepository _userRepository;
        private readonly IParticipantRepository _participantRepository;

        public ParticipantFilter(IUserRepository userRepository, IParticipantRepository participantRepository) {
            _userRepository = userRepository;
            _participantRepository = participantRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                GUser user = _userRepository.GetByEmail(context.HttpContext.User.Identity.Name);
                Participant participant = _participantRepository.GetBy(user.UserId);
                context.ActionArguments["participant"] = participant;
            }
            base.OnActionExecuting(context);
        }
    }
}
