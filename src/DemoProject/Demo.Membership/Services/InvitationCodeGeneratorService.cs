using Demo.Membership.BusinessObjects;
using Demo.Membership.UnitOfWorks;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Membership.Services
{
    public class InvitationCodeGeneratorService : IInvitationCodeGeneratorService
    {
        private readonly IMembershipUnitOfWork _unitOfWork;

        public InvitationCodeGeneratorService(IMembershipUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void GetData(string invitationCode)
        {
           var entity = _unitOfWork.UserInfoRepository.GetCount( x => x.InvitationCode == invitationCode) > 0;
        }

        public async Task SetInvitationCode(UserInfo invitation)
        {
            await _unitOfWork.UserInfoRepository.AddAsync(
                new Entities.UserInfo() { 
                    InvitationCode = invitation.InvitationCode,
                    Email = invitation.Email
                });

            await _unitOfWork.SaveAsync();
        }

        async Task<UserInfo> IInvitationCodeGeneratorService.GetData(string invitationCode)
        {
            var entity = await _unitOfWork.UserInfoRepository.GetAllAsync();

            var en = (await _unitOfWork.UserInfoRepository.GetAsync(c => c.InvitationCode == invitationCode, null)).FirstOrDefault();

            return default;
        }
    }
}