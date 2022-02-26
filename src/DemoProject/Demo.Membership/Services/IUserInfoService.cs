using Demo.Membership.BusinessObjects;
using System.Threading.Tasks;

namespace Demo.Membership.Services
{
    public interface IUserInfoService
    {
        Task<UserInfo> GetEmailAsync(string invitationCode);
    }
}