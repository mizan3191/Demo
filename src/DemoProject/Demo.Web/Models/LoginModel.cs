using Autofac;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Web.Models
{
    public class LoginModel
    {
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        
        public string ReturnUrl { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        private ILifetimeScope _scope;

        public LoginModel()
        {
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}