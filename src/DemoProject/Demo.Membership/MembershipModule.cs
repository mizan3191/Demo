using Autofac;
using Demo.Membership.Contexts;
using Demo.Membership.Repositories;
using Demo.Membership.Services;
using Demo.Membership.UnitOfWorks;

namespace Demo.Membership
{
    public class MembershipModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public MembershipModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<MembershipDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<MembershipDbContext>().As<IMembershipDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<UserInfoRepository>().As<IUserInfoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserInfoService>().As<IUserInfoService>().InstancePerLifetimeScope();
            builder.RegisterType<MembershipUnitOfWork>().As<IMembershipUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<InvitationCodeGeneratorService>().As<IInvitationCodeGeneratorService>().InstancePerLifetimeScope();
            builder.RegisterType<InvitationRepository>().As<IInvitationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();

            builder.RegisterType<EmailService>().As<IEmailService>()
                .WithParameter("host", "")
                .WithParameter("port", )
                .WithParameter("username", "")
                .WithParameter("password", "")
                .WithParameter("useSSL", true)
                .WithParameter("from", "")
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}