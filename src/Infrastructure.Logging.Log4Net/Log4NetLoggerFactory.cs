using System;

namespace Infrastructure.Logging.Log4Net
{
	/// <summary>
	/// A Trace Source base, log factory
	/// </summary>
	public class Log4NetLoggerFactory
		: ILoggerFactory
	{
		static Log4NetLoggerFactory()
		{
			LoggerFactory.SetCurrent(new Log4NetLoggerFactory());
		}

		/// <summary>
		/// Create the Log4Net source log
		/// </summary>
		/// <param name="type">The type creating a  logger for</param>
		/// <returns>New ILog based on Trace Source infrastructure</returns>
		public ILogger Create(Type type)
		{
			return new Log4NetLogger(type);
		}
	}
}