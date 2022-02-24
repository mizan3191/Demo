using DevSkill.Data;
using System;

namespace Demo.Membership.Entities
{
    public class UserInfo : IEntity<int>
    {
        public int Id { get; set; }
        public string SecretCode { get; set; }
        public ApplicationUser SuperAdmin { get; set; }
    }
}