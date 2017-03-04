using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using dotnet_g23.Models.Domain;
using System;

namespace dotnet_g23.Filters {
    public class ParticipantFilter : ActionFilterAttribute {
        private readonly IUserRepository _userRepository;
        private GUser _participant;

        public ParticipantFilter(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            _participant = ReadParticipantFromSession(context.HttpContext);
            context.ActionArguments["participant"] = _participant;
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context) {
            WriteParticipantToSession(_participant, context.HttpContext);
            base.OnActionExecuted(context);
        }

        private void WriteParticipantToSession(GUser participant, HttpContext context) {
            context.Session.SetString("participant", JsonConvert.SerializeObject(participant));
        }

        private GUser ReadParticipantFromSession(HttpContext context) {
            GUser user = context.Session.GetString("participant") == null ?
                new GUser(null, null) : JsonConvert.DeserializeObject<GUser>(context.Session.GetString("participant"));
            foreach (var l in _userRepository.GetAll()) {
                if (l.UserState.GetType().Name == "Participant")
                    return l;
               }
            return user;
        }
    }
}
