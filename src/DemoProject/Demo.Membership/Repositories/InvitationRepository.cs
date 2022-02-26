using Demo.Membership.Contexts;
using Demo.Membership.Entities;
using DevSkill.Data;

namespace Demo.Membership.Repositories
{
    internal class InvitationRepository : Repository<Invitation, int, MembershipDbContext>, IInvitationRepository
    {
        public InvitationRepository(IMembershipDbContext dbContext)
            : base((MembershipDbContext)dbContext)
        {
        }
    }
}