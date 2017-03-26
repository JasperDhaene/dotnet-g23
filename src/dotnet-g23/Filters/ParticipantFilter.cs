using dotnet_g23.Models.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;

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
                var participant = _participantRepository.GetByEmail(context.HttpContext.User.Identity.Name);
                context.ActionArguments["participant"] = participant;
            }
            base.OnActionExecuting(context);
        }
    }
}