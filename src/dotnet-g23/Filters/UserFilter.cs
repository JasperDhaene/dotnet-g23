using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;

namespace dotnet_g23.Filters {
    public class UserFilter : ActionFilterAttribute {
        private readonly IUserRepository _userRepository;

        public UserFilter(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                GUser _user = _userRepository.GetByEmail(context.HttpContext.User.Identity.Name);
                context.ActionArguments["user"] = _user;
            }
            base.OnActionExecuting(context);
        }
    }
}