using AutoMapper;
using Demo.Membership.BusinessObjects;
using Demo.Web.Models;

namespace Demo.Web.Profiles
{
    public class WebProfiles : Profile
    {
        public WebProfiles()
        {
            CreateMap<ProductCreateModel, Product>().ReverseMap();
            CreateMap<ProductEditModel, Product>().ReverseMap();
        }
    }
}