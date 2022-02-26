using Microsoft.AspNetCore.Authorization;

namespace Demo.Membership.BusinessObjects
{
    public class ManagerRequirement : IAuthorizationRequirement
    {
        public ManagerRequirement()
        {
        }
    }
}