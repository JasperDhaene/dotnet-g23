using dotnet_g23.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g23.Models.Domain.Repositories;

namespace dotnet_g23.Filters
{
    public class OrganizationFilter : ActionFilterAttribute {
        private readonly IOrganizationRepository _organizationRepository;
        private Organization _organization;

        public OrganizationFilter(IOrganizationRepository organizationRepository) {
            _organizationRepository = organizationRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            _organization = ReadOrganizationFromSession(context.HttpContext);
            context.ActionArguments["organization"] = _organization;
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context) {
            WriteOrganizationToSession(_organization, context.HttpContext);
            base.OnActionExecuted(context);
        }

        private void WriteOrganizationToSession(Organization organization, HttpContext context) {
            context.Session.SetString("organization", JsonConvert.SerializeObject(organization));
        }

        private Organization ReadOrganizationFromSession(HttpContext context) {
            Organization organization = context.Session.GetString("organization") == null ?
                new Organization(null, null, null) : JsonConvert.DeserializeObject<Organization>(context.Session.GetString("organization"));
            foreach(var l in organization.Groups) {
                l.Organization = _organizationRepository.GetBy(l.Organization.OrganizationId);
            }
            return organization;
        }
    }
}