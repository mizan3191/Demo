using Demo.Membership.BusinessObjects;
using System.Threading.Tasks;

namespace Demo.Membership.Services
{
    public interface IInvitationCodeGeneratorService
    {
        Task SetInvitationCode(UserInfo invitation);
        Task<UserInfo> GetData(string invitationCode);
    }
}