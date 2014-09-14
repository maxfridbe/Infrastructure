using Autofac;

namespace Infrastructure.Logging.Log4Net
{
	/// <summary>
	/// This is the module you link against if you want to use autofac
	/// AND have a dependency not on Log4Net but Infrastructure.Logging 
	/// </summary>
	public class Log4NetAutofacModule : Module
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

		protected override void Load(ContainerBuilder builder)
		{
		    builder.RegisterType<Log4NetLoggerFactory>().SingleInstance().AsImplementedInterfaces();
		}
	}
}
