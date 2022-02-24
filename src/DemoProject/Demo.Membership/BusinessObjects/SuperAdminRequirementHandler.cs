using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Membership.BusinessObjects
{
    public class SuperAdminRequirementHandler : 
        AuthorizationHandler<SuperAdminRequirement>
    {
        protected override Task HandleRequirementAsync(
               AuthorizationHandlerContext context,
               SuperAdminRequirement requirement)
        {
            var claim = context.User.FindFirst("SuperAdmin");

            if (claim != null && bool.Parse(claim.Value))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
