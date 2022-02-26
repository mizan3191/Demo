using Demo.Membership.BusinessObjects;
using Demo.Membership.UnitOfWorks;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Membership.Services
{
    public class UserInfoService : IUserInfoService
    {
        private IMembershipUnitOfWork _unitOfWork;
        
        public UserInfoService(IMembershipUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<UserInfo> GetEmailAsync(string invitationCode)
        {
            var entity = (await _unitOfWork.UserInfoRepository.GetAsync(c => c.InvitationCode == invitationCode, null)).FirstOrDefault();

            if (entity == null)
                throw new Exception("User is doesn't exist");

            return new UserInfo()
            {
                Email = entity.Email,
                InvitationCode = invitationCode,
                Id = entity.Id
            };
        }
    }
}