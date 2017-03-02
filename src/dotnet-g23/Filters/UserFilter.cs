using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Beerhall.Filters {
    public class CustomerFilter : ActionFilterAttribute {
        private readonly IUserRepository _userRepository;

        public CustomerFilter(IUserRepository userRespoitory) {
            _userRepository = userRespoitory;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            context.ActionArguments["guser"] = context.HttpContext.User.Identity.IsAuthenticated ? _userRepository.GetByEmail(context.HttpContext.User.Identity.Name) : null;
            base.OnActionExecuting(context);
        }
    }
}