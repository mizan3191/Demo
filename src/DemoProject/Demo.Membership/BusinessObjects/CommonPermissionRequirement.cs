using Microsoft.AspNetCore.Authorization;

namespace Demo.Membership.BusinessObjects
{
    public class CommonPermissionRequirement : IAuthorizationRequirement
    {
        public CommonPermissionRequirement()
        {
        }
    }
}