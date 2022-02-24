using AutoMapper;
using EO = Demo.Membership.Entities;
using BO = Demo.Membership.BusinessObjects;

namespace Demo.Membership.Profiles
{
    public class MembershipProfile : Profile
    {
        public MembershipProfile()
        {
            CreateMap<EO.UserInfo, BO.UserInfo>().ReverseMap();
        }
    }
}