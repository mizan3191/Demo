using DevSkill.Data;

namespace Demo.Membership.Entities
{
    public class Invitation : IEntity<int>
    {
        public int Id { get; set; }
        public string InvitationCode { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}