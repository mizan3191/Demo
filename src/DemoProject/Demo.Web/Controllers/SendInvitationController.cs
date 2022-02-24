using Autofac;
using Demo.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Demo.Web.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class SendInvitationController : Controller
    {
        private readonly ILogger<SendInvitationController> _logger;
        private readonly ILifetimeScope _scope;

        public SendInvitationController(ILogger<SendInvitationController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public async Task<IActionResult> Invitation()
        {
            var model = _scope.Resolve<UserInvitationModel>();
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
