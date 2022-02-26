using DevSkill.Data;

namespace Demo.Membership.Entities
{
    public class UserInfo : IEntity<int>
    {
        public int Id { get; set; }
        public string InvitationCode { get; set; }
        public string Email { get; set; }
    }
}