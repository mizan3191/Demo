using Demo.Membership.Contexts;
using Demo.Membership.Entities;
using DevSkill.Data;

namespace Demo.Membership.Repositories
{
    public interface IInvitationRepository : IRepository<Invitation, int, MembershipDbContext>
    {
    }
}