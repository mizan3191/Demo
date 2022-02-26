using System;
using Microsoft.AspNetCore.Identity;

namespace Demo.Membership.Entities
{
    public class UserClaim
        : IdentityUserClaim<Guid>
    {
    }
}