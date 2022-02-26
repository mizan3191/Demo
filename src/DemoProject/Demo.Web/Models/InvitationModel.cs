using Autofac;
using BO = Demo.Membership.BusinessObjects;
using Demo.Membership.Services;
using System.Threading.Tasks;

namespace Demo.Web.Models
{
    public class InvitationModel
    {
        public string Email { get; set; }
        public bool Manager { get; set; }
        public bool User { get; set; }
        public string InvitationCode { get; set; }

        private ILifetimeScope _scope;
        private IInvitationCodeGeneratorService _invitationCode;
        
        public InvitationModel(IInvitationCodeGeneratorService invitationCode)
        {
            _invitationCode = invitationCode;
        }
        
        public InvitationModel()
        {
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _invitationCode = _scope.Resolve<IInvitationCodeGeneratorService>();
        }

        internal async Task SetInvitationCode(string email)
        {

            var invitation = new BO.UserInfo()
            {
                InvitationCode = InvitationCode,
                Email = email
            };

            await _invitationCode.SetInvitationCode(invitation);
        }
    }
}