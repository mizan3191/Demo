using Autofac;
using Demo.Membership.Entities;
using Demo.Membership.Services;
using Demo.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Demo.Web.Controllers
{
    [Authorize(Policy = "SuperAdmin")]
    public class SendInvitationController : Controller
    {
        private readonly ILogger<SendInvitationController> _logger;
        private readonly ILifetimeScope _scope;
        private readonly IEmailService _emailService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SendInvitationController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILifetimeScope scope,
            IEmailService emailService,
            ILogger<SendInvitationController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _scope = scope;
            _emailService = emailService;
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Invitation()
        {
            var model = _scope.Resolve<InvitationModel>();

            return View(model);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Invitation(InvitationModel model)
        {
            model.Resolve(_scope);

            if (ModelState.IsValid)
            {
                var code = Guid.NewGuid().ToString();
                model.InvitationCode = code.Replace("-", "");
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);

                if(model.User == true)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    await _userManager.AddClaimAsync(user, new Claim("User", "true"));
                }
                if(model.Manager == true)
                {
                    await _userManager.AddToRoleAsync(user, "Manager");
                    await _userManager.AddClaimAsync(user, new Claim("Manager", "true"));
                }

                await model.SetInvitationCode(model.Email);
                var codes = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                codes = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(codes));

                var callbackUrl = Url.ActionLink(
                    "/Account/Login",
                    values: new { area = "Identity", userId = user.Id, codes = codes },
                    protocol: Request.Scheme);

                _emailService.SendEmail(model.Email, "Login Code",
                    $"Please login your account by using ({model.InvitationCode}) <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'> Clicking Here</a>.");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}