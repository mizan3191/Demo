using Demo.Membership.Repositories;
using DevSkill.Data;

namespace Demo.Membership.UnitOfWorks
{
    public interface IMembershipUnitOfWork : IUnitOfWork
    {
        public IUserInfoRepository UserInfoRepository { get; }
    }
}