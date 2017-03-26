using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using dotnet_g23.Models.Domain;
using System;
using dotnet_g23.Models.Domain.Repositories;

namespace dotnet_g23.Filters
{
    public class ParticipantFilter : ActionFilterAttribute
    {
        private readonly IParticipantRepository _participantRepository;

        public ParticipantFilter(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                Participant participant = _participantRepository.GetByEmail(context.HttpContext.User.Identity.Name);
                context.ActionArguments["participant"] = participant;
            }
            base.OnActionExecuting(context);
        }
    }
}