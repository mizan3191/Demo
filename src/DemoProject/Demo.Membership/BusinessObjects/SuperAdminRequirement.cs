using Microsoft.AspNetCore.Authorization;

namespace Demo.Membership.BusinessObjects
{
    public class SuperAdminRequirement : IAuthorizationRequirement
    {
        public SuperAdminRequirement()
        {
        }
    }
}