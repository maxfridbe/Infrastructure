using Autofac;

namespace Infrastructure.Security.IOC
{
    public class SecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PBKDF2PasswordHashProvider>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<SingleKeyEncryptionService>().AsImplementedInterfaces().SingleInstance();

        }
    }
}
