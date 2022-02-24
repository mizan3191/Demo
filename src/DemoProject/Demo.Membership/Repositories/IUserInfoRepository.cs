using Demo.Membership.Contexts;
using Demo.Membership.Entities;
using DevSkill.Data;

namespace Demo.Membership.Repositories
{
    public interface IUserInfoRepository : IRepository<UserInfo, int, MembershipDbContext>
    {
    }
}