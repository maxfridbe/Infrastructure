using System;
using System.Linq;
using Autofac;
using Autofac.Core;

namespace Infrastructure.Logging.AutoFac
{
    /// <summary>
    /// This is the module you link against if you want to use autofac
    /// AND have a dependency not on Log4Net but Infrastructure.Logging 
    /// </summary>
    public class LoggerAutoFacModule : Module
    {
        //protected override void AttachToComponentRegistration(IComponentRegistry registry, IComponentRegistration registration)
        //{
        //    registration.Preparing += OnComponentPreparing;
        //}

        //static void OnComponentPreparing(object sender, PreparingEventArgs e)
        //{
        //    var t = e.Component.Activator.LimitType;
        //    e.Parameters = e.Parameters.Union(new[]
        //                                        {
        //                                            new ResolvedParameter((p, i) => p.ParameterType == typeof (ILogger),
        //                                                                  (p, i) => LoggerFactory.CreateLog(t))
        //                                        });
        //}
        protected override void AttachToComponentRegistration(
        IComponentRegistry registry, IComponentRegistration registration)
        {
            registration.Preparing +=
                (sender, args) =>
                {
                    var forType = args.Component.Activator.LimitType;

                    var logParameter = new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(ILogger),
                        (p, c) => c.Resolve<ILogger>(TypedParameter.From(forType)));

                    args.Parameters = args.Parameters.Union(new[] { logParameter });
                };
        }
        protected override void Load(ContainerBuilder builder)
        {

            builder.Register<ILogger>((c, p) =>
            {
                var fac = c.Resolve<ILoggerFactory>();
                return fac.Create(p.TypedAs<Type>());
            });
            //Container.Resolve<ILogger>(TypedParameter.From(type));
        }
    }
}
