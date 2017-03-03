using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using dotnet_g23.Models.Domain;
using System;

namespace dotnet_g23.Filters {
    public class LectorFilter : ActionFilterAttribute {
        private readonly IUserRepository _userRepository;
        private GUser _lector;

        public LectorFilter(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            _lector = ReadLectorFromSession(context.HttpContext);
            context.ActionArguments["lector"] = _lector;
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context) {
            WriteLectorToSession(_lector, context.HttpContext);
            base.OnActionExecuted(context);
        }

        private void WriteLectorToSession(GUser lector, HttpContext context) {
            context.Session.SetString("lector", JsonConvert.SerializeObject(lector));
        }

        private GUser ReadLectorFromSession(HttpContext context) {
            GUser user = context.Session.GetString("lector") == null ?
                new GUser(null, null) : JsonConvert.DeserializeObject<GUser>(context.Session.GetString("lector"));
            foreach (var l in _userRepository.GetAll()) {
                if (l.UserState.GetType().Name == "Lector")
                    return l;
            }
            return user;
        }
    }
}
