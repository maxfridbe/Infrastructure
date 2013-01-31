using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Infrastructure.Logging.Log4Net
{
	public class Log4NetLogger : ILogger
	{
		readonly ILog _logger;
		public Log4NetLogger(Type type)
		{
			_logger = LogManager.GetLogger(type);
		}
		public Log4NetLogger(string name)
		{
			_logger = LogManager.GetLogger(name);
		}

		public void Debug(string message, params object[] args)
		{
			_logger.DebugFormat(message, args);
		}

		public void Info(string message, params object[] args)
		{
			_logger.InfoFormat(message, args);
		}

		public void Perf(string message, params object[] args)
		{
			_logger.InfoFormat(message, args);
		}

		public void Warning(string message, params object[] args)
		{
			_logger.WarnFormat(message, args);
		}

		public void Error(string message, params object[] args)
		{
			_logger.ErrorFormat(message, args);
		}

		public void Error(string message, Exception exception, params object[] args)
		{
			_logger.Error(string.Format(message, args), exception);
		}

		public void Fatal(string message, params object[] args)
		{
			_logger.FatalFormat(message, args);
		}
		public void Fatal(string message, Exception exception, params object[] args)
		{
			_logger.Fatal(string.Format(message, args), exception);
		}
	}
}

