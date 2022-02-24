using Microsoft.AspNetCore.Identity;
using System;

namespace Demo.Membership.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
    }
}