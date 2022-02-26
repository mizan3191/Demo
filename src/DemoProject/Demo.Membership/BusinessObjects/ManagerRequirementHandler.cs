using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Demo.Membership.BusinessObjects
{
    public class ManagerRequirementHandler : AuthorizationHandler<ManagerRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ManagerRequirement requirement)
        {
            var claim = context.User.FindFirst("Manager");

            if(claim != null && bool.Parse(claim.Value))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}