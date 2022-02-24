using System;

namespace Demo.Membership.BusinessObjects
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MobileNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Gender { get; set; } 
    }
}
