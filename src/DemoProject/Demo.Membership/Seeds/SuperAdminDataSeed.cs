using Demo.Membership.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Demo.Membership.Seeds
{
    public class SuperAdminDataSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SuperAdminDataSeed(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedUserAsync()
        {
            var superAdminUser = new ApplicationUser
            {
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true
            };

            IdentityResult result = null;
            var password = "Hello@Admin";

            if (await _userManager.FindByEmailAsync(superAdminUser.Email) == null)
            {
                result = await _userManager.CreateAsync(superAdminUser, password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");
                    await _userManager.AddClaimAsync(superAdminUser, new Claim("SuperAdmin", "true"));
                }
            }
        }
    }
}