﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Membership.BusinessObjects
{
    public class ManagerRequirement : IAuthorizationRequirement
    {
        public ManagerRequirement()
        {

        }
    }
}
