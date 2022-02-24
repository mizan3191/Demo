using Autofac;
using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Web.Models
{
    public class UserInvitationModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name should be less than 100 characters")]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}")]
        public string Email { get; set; }
        public string Status { get; set; }
        public string InvitationCode { get; set; }
        public Guid CompanyId { get; set; }
        private ILifetimeScope _scope;
        
        public UserInvitationModel()
        {
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}
