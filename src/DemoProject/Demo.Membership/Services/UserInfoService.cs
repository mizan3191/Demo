using Demo.Membership.BusinessObjects;
using Demo.Membership.UnitOfWorks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Membership.Services
{
    public class UserInfoService : IUserInfoService
    {
        private IMembershipUnitOfWork _unitOfWork;
        
        public UserInfoService(IMembershipUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
    }
}