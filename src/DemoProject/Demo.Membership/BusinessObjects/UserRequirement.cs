using Microsoft.AspNetCore.Authorization;

namespace Demo.Membership.BusinessObjects
{
    public class UserRequirement : IAuthorizationRequirement
    {
        public UserRequirement()
        {

        }
    }
}