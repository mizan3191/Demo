using Demo.Membership.Contexts;
using Demo.Membership.Repositories;
using Demo.Membership.UnitOfWorks;
using DevSkill.Data;

namespace Demo.Membership.UnitOfWorks
{
    public class MembershipUnitOfWork : UnitOfWork, IMembershipUnitOfWork
    {
        public IUserInfoRepository UserInfoRepository { get; private set; }

        public MembershipUnitOfWork(IMembershipDbContext dbContext, 
            IUserInfoRepository userInfoRepository)
            : base((MembershipDbContext)dbContext)
        {
            UserInfoRepository = userInfoRepository;
        }
    }
}