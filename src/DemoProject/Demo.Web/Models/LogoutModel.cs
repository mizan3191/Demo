using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Web.Models
{
    public class LogoutModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private ILifetimeScope _scope;

        public LogoutModel()
        {
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
        }

    }
}
