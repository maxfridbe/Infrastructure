using System;

namespace Infrastructure.Logging
{
	class DiagnosticsLogger:ILogger
	{
		#region Implementation of ILogger

		public void Debug(string message, params object[] args)
		{
			System.Diagnostics.Debug.WriteLine(message,args);
		}

		public void Info(string message, params object[] args)
		{
			System.Diagnostics.Debug.WriteLine(message, args);
		}

		public void Perf(string message, params object[] args)
		{
			System.Diagnostics.Debug.WriteLine(message, args);
		}

		public void Warning(string message, params object[] args)
		{
			System.Diagnostics.Debug.WriteLine(message, args);
		}

		public void Error(string message, params object[] args)
		{
			System.Diagnostics.Debug.WriteLine(message, args);
		}

		public void Error(string message, Exception exception, params object[] args)
		{
			System.Diagnostics.Debug.WriteLine(message, args);
		}

		public void Fatal(string message, params object[] args)
		{
			System.Diagnostics.Debug.WriteLine(message, args);
		}

		public void Fatal(string message, Exception exception, params object[] args)
		{
			System.Diagnostics.Debug.WriteLine(message, args);
		}

		#endregion
	}
}