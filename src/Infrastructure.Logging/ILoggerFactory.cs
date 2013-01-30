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
	/// Base contract for Log abstract factory
	/// </summary>
	public interface ILoggerFactory
	{
		/// <summary>
		/// Creates an ILogger with the source being the type
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		ILogger Create(Type type);
	}
}
