using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Membership.BusinessObjects
{
    public class CommonPermissionRequirementHandler :
        AuthorizationHandler<CommonPermissionRequirement>
    {
        protected override Task HandleRequirementAsync(
               AuthorizationHandlerContext context,
               CommonPermissionRequirement requirement)
        {
            var claims = context.User.Claims;

            foreach (var claim in claims.ToList())
            {
                if (claim.Value == "SuperAdmin" || claim.Value == "Manager" || claim.Value == "User")
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}