using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using dotnet_g23.Models.Domain;
using System;
using dotnet_g23.Models.Domain.Repositories;

namespace dotnet_g23.Filters {
    public class ParticipantFilter : ActionFilterAttribute {
        private readonly IUserRepository _userRepository;

        public ParticipantFilter(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                GUser user = _userRepository.GetByEmail(context.HttpContext.User.Identity.Name);
                context.ActionArguments["participant"] = user.UserState as Participant;
            }
            base.OnActionExecuting(context);
        }
    }
}
