using Demo.Membership.Entities;

namespace Demo.Membership.BusinessObjects
{
    public class Invitation
    {
        public int Id { get; set; }
        public string InvitationCode { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}