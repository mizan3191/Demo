using Demo.Membership.Contexts;
using Demo.Membership.Entities;
using DevSkill.Data;

namespace Demo.Membership.Repositories
{
    public class UserInfoRepository : Repository<UserInfo, int, MembershipDbContext>, IUserInfoRepository
    {
        public UserInfoRepository(IMembershipDbContext dbContext)
            :base((MembershipDbContext)dbContext)
        {

        }
    }
}