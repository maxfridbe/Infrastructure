using System;
using System.ServiceProcess;
using Infrastructure.Logging;

namespace Infrastructure.WindowsService
{
	public class ServiceInitializer
	{
		private readonly ILogger _logger;
		private readonly OperationWindowsService _operationWindowsService;

		public ServiceInitializer(ILogger logger, OperationWindowsService opservice)
		{
			_logger = logger;
			_operationWindowsService = opservice;
			_logger.Debug("ServiceInitializer Constructed");
		}

		public void Initialize(string[] args)
		{
			try
			{
				_logger.Debug("Setting Current Dir");
				System.IO.Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

				AppDomain.CurrentDomain.UnhandledException += (o, e) => _logger.Fatal("Unhandled exception.", e);
				AppDomain.CurrentDomain.ProcessExit += (o, e) => _logger.Warning("Process exit, ExitCode:{0}", _operationWindowsService.ExitCode);

				_logger.Info("--------------------------------------------------------------");
				_logger.Info("Starting...");

				if (Environment.UserInteractive)
				{
					Console.WriteLine("interactive");
					var task = _operationWindowsService.StartConsole(args);

					_logger.Debug("Started.");
					_logger.Debug("Listening for a key to be hit to stop the service.");
					Console.ReadLine();
					_logger.Debug("Stopping due to key hit.");


					_operationWindowsService.Stop();
					_logger.Debug("Waiting 30 seconds for task to complete");
					task.Wait(TimeSpan.FromSeconds(30));

					_logger.Debug("Stopped.");
					_logger.Warning("Application Ended");
				}
				else
				{
					_logger.Info("ServiceBase.Run Calling");
					ServiceBase.Run(_operationWindowsService);
				}
			}
			catch (Exception e)
			{
				_logger.Fatal("Runtime exception", e);
				throw;
			}
		}
	}
}