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
    /// Common contract for trace instrumentation. You 
    /// can implement this contract with several frameworks.
    /// .NET DiagnosticsLogger API, EntLib, Log4Net,NLog etc.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log debug message.
        /// </summary>
        /// <param name="message">The debug message to write</param>
        /// <param name="args">The argument values</param>
        void Debug(string message, params object[] args);

        /// <summary>
        /// Log message information 
        /// </summary>
        /// <param name="message">The information message to write</param>
        /// <param name="args">The arguments values</param>
        void Info(string message, params object[] args);

        /// <summary>
        /// Log performance message.
        /// </summary>
        /// <param name="message">The performance message to write</param>
        /// <param name="args">The argument values</param>
        void Perf(string message, params object[] args);

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message">The warning message to write</param>
        /// <param name="args">The argument values</param>
        void Warning(string message, params object[] args);

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>
        /// <param name="args">The arguments values</param>
        void Error(string message, params object[] args);

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>
        /// <param name="exception">The exception associated with this error</param>
        /// <param name="args">The arguments values</param>
        void Error(string message, Exception exception, params object[] args);

        /// <summary>
        /// Log fatal message
        /// </summary>
        /// <param name="message">The fatal message to write</param>
        /// <param name="args">The argument values</param>
        void Fatal(string message, params object[] args);

        /// <summary>
        /// Log fatal message
        /// </summary>
        /// <param name="message">The fatal message to write</param>
        /// <param name="exception">The exception associated with this error</param>
        /// <param name="args">The argument values</param>
        void Fatal(string message, Exception exception, params object[] args);
    }
}
