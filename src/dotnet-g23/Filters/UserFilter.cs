﻿using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Mvc.Filters;

namespace dotnet_g23.Filters {
    public class UserFilter : ActionFilterAttribute {
        private readonly IUserRepository _userRepository;
        private GUser _user;

        public UserFilter(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            if (context.HttpContext.User.Identity.IsAuthenticated)
                _user = _userRepository.GetByEmail(context.HttpContext.User.Identity.Name);
            context.ActionArguments["guser"] = _user;
            base.OnActionExecuting(context);
        }
    }
}