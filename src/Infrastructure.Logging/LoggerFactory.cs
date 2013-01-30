//===================================================================================
// Microsoft Developer & Platform Evangelism
//=================================================================================== 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
// This code is released under the terms of the MS-LPL license, 
// http://microsoftnlayerapp.codeplex.com/license
//===================================================================================


using System;

namespace Infrastructure.Logging
{
	/// <summary>
	/// Log Factory
	/// </summary>
	public static class LoggerFactory
	{
		#region Members

		static ILoggerFactory _currentLogFactory = null;

		#endregion

		#region Public Methods

		/// <summary>
		/// Set the  log factory to use
		/// </summary>
		/// <param name="logFactory">Log factory to use</param>
		public static void SetCurrent(ILoggerFactory logFactory)
		{
			_currentLogFactory = logFactory;
		}

		/// <summary>
		/// Create a new <paramref name="ILogger"/>
		/// </summary>
		/// <returns>Created ILogger</returns>
		public static ILogger CreateLog(Type type)
		{
			if (_currentLogFactory !=null)
				return _currentLogFactory.Create(type);
			
			_currentLogFactory = new DiagnosticsLoggerFactory();
			return _currentLogFactory.Create(type);
		}

		#endregion
	}
}
