using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Logging;

namespace Infrastructure.Operations
{
	public abstract class ServiceOperationBase : IServiceOperation
	{
		private CancellationToken _token;
		private readonly ILogger _logger;
		public abstract void Operation();

		protected ServiceOperationBase(ILogger logger)
		{
			_logger = logger;
			_logger.Info("Initializing ServiceOperationBase");
		}

		#region Implementation of IServiceOperation

		public Task Preform(CancellationToken token, TimeSpan repeatDelay)
		{
			_token = token;
			var task = new Task(t =>
			{
				while (!_token.IsCancellationRequested)
				{
					try
					{
						Operation();
					}
					catch (Exception e)
					{
						_logger.Fatal("Exception occurred in Main Task", e);
					}
					_token.WaitHandle.WaitOne(repeatDelay);
				} //end while
				_logger.Debug("Outside Main While Loop");
			}, _token);

			task.ContinueWith(t =>
			{
				_logger.Debug("Main Task Thread Completed");
				if (t.Exception != null)
					_logger.Fatal("Exception in main task", t.Exception);
			});
			task.Start();
			_logger.Debug("Task Started");
			return task;
		}

		#endregion
	}
}
