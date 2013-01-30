using System;

namespace Infrastructure.Logging
{
	class DiagnosticsLoggerFactory :ILoggerFactory
	{
		#region Implementation of ILoggerFactory

		public ILogger Create(Type type)
		{
			return new DiagnosticsLogger();
		}

		#endregion
	}
}