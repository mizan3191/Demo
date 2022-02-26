using Autofac;
using Demo.Web.Models;

namespace Demo.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginModel>().AsSelf();
            builder.RegisterType<InvitationModel>().AsSelf();
            builder.RegisterType<UserLoginModel>().AsSelf();
            builder.RegisterType<ProductTableModel>().AsSelf();
            builder.RegisterType<ProductEditModel>().AsSelf();
            builder.RegisterType<ProductCreateModel>().AsSelf();

            base.Load(builder);
        }
    }
}