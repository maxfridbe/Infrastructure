using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using log4net;

namespace Infrastructure.AutoFac.Log4Net
{
	/// <summary>
	/// This is the module you link against if you want to use autofac
	/// AND have a dependency on log4net
	/// </summary>
	public class LoggerAutoFacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);
			builder.Register<ILog>((c, p) => LogManager.GetLogger(p.TypedAs<Type>()));
			//Container.Resolve<ILogger>(TypedParameter.From(type));
		}
	}
}
