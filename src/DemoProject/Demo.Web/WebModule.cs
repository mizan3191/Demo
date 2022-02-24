using Autofac;
using Demo.Web.Models;

namespace Demo.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginModel>().AsSelf();
            builder.RegisterType<RegisterModel>().AsSelf();
            builder.RegisterType<UserInvitationModel>().AsSelf();


            base.Load(builder);
        }
    }
}