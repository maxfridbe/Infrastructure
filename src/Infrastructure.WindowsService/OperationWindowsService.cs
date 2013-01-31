using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Logging;
using Infrastructure.Operations;

namespace Infrastructure.WindowsService
{
	public class OperationWindowsService : ServiceBase
	{
		private readonly ILogger _logger;
		private readonly IServiceOperation _operation;
		private readonly TimeSpan _operationDelay;
		private TimeSpan _startupDelay;
		private CancellationTokenSource TokenSource { get; set; }
		private Task _currentTask;

		public OperationWindowsService(ILogger logger, 
										IServiceOperation operation, 
										TimeSpan operationDelay,
										TimeSpan startupDelay)
		{
			_logger = logger;
			_operation = operation;
			_operationDelay = operationDelay;
			_startupDelay = startupDelay;
		}

		public Task StartConsole(string[] args)
		{
			_logger.Info("Console Mode Starting");

			OnStart(args);
			return _currentTask;
		}

		protected override void OnStart(string[] args)
		{
			if (!Environment.UserInteractive)
				this.RequestAdditionalTime((int)_startupDelay.TotalMilliseconds);
			_logger.Info("Start called.");

			TokenSource = new CancellationTokenSource();
			try
			{
				_currentTask = _operation.Preform(TokenSource.Token, _operationDelay);
				base.OnStart(args);
			}
			catch (Exception e)
			{
				_logger.Fatal("Exception attempting to start OperationWindowsService", e);
				OnStop();
			}
		}

		protected override void OnStop()
		{
			_logger.Warning("OnStop Called");
			_logger.Warning("Posting cancel to token source");
			TokenSource.Cancel();
			base.OnStop();
		}
	}
}
