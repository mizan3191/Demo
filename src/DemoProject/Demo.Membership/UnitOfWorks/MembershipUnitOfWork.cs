using Demo.Membership.Contexts;
using Demo.Membership.Repositories;
using DevSkill.Data;

namespace Demo.Membership.UnitOfWorks
{
    public class MembershipUnitOfWork : UnitOfWork, IMembershipUnitOfWork
    {
        public IUserInfoRepository UserInfoRepository { get; private set; }
        public IInvitationRepository InvitationRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }

        public MembershipUnitOfWork(IMembershipDbContext dbContext, 
            IUserInfoRepository userInfoRepository,
            IProductRepository productRepository,
            IInvitationRepository invitationRepository)
            : base((MembershipDbContext)dbContext)
        {
            UserInfoRepository = userInfoRepository;
            InvitationRepository = invitationRepository;
            ProductRepository = productRepository;
        }
    }
}