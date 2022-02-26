using Autofac;
using Demo.Membership.Services;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Web.Models
{
    public class UserLoginModel
    {
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }
        public string InvitationCode { get; set; }
        public string Email { get; set; }

        private ILifetimeScope _scope;
        private IUserInfoService _service;

        public UserLoginModel(IUserInfoService service)
        {
            _service = service;
        }

        public UserLoginModel()
        {
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IUserInfoService>();
        }

        internal async Task GetEmailAsync(string invitationCode)
        {
            var email = await _service.GetEmailAsync(invitationCode);

            if (email != null)
            {
                Email = email.Email;
                InvitationCode = email.InvitationCode;
            }
        }
    }
}