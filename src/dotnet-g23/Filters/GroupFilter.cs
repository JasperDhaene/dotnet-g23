using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using dotnet_g23.Models.Domain;

namespace dotnet_g23.Filters {
    public class GroupFilter : ActionFilterAttribute {
        private readonly IGroupRepository _groupRepository;
        private Group _group;

        public GroupFilter(IGroupRepository groupRepository) {
            _groupRepository = groupRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            _group = ReadGroupFromSession(context.HttpContext);
            context.ActionArguments["group"] = _group;
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context) {
            WriteGroupToSession(_group, context.HttpContext);
            base.OnActionExecuted(context);
        }

        private Group ReadGroupFromSession(HttpContext context) {
            Group group = context.Session.GetString("group") == null ?
                new Group(null) : JsonConvert.DeserializeObject<Group>(context.Session.GetString("group"));
            foreach (var l in group.Participants)
                l.Group = _groupRepository.GetBy(l.Group.GroupId);
            return group;
        }

        private void WriteGroupToSession(Group group, HttpContext context) {
            context.Session.SetString("group", JsonConvert.SerializeObject(group));
        }
    }
}
