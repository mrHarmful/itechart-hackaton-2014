using System;
using log4net;

namespace Seed.Logging
{
    public static class Logger
    {
        #region Private fields

        private static readonly ILog DebugLog = LogManager.GetLogger("DebugLogger");

        private static readonly ILog InfoLog = LogManager.GetLogger("InfoLogger");

        private static readonly ILog WarnLog = LogManager.GetLogger("WarnLogger");

        private static readonly ILog ErrorLog = LogManager.GetLogger("ErrorLogger");

        private static readonly ILog FaralErrorLog = LogManager.GetLogger("FatalErrorLogger");

        #endregion

        #region Public methods

        public static void Debug(string message)
        {
            DebugLog.Debug(message);
        }

        public static void DebugFormat(string message, params object[] args)
        {
            DebugLog.DebugFormat(message, args);
        }

        public static void Info(string message)
        {
            InfoLog.Info(message);
        }

        public static void InfoFormat(string message, params object[] args)
        {
            InfoLog.InfoFormat(message, args);
        }

        public static void Warn(string message)
        {
            WarnLog.Warn(message);
        }

        public static void WarnFormat(string message, params object[] args)
        {
            WarnLog.WarnFormat(message, args);
        }

        public static void Error(string message)
        {
            ErrorLog.Error(message);
        }

        public static void ErrorFormat(string message, params object[] args)
        {
            ErrorLog.ErrorFormat(message, args);
        }

        public static void Error(string message, Exception exception)
        {
            ErrorLog.Error(message, exception);
        }

        public static void ErrorFormat(string message, Exception exception, params object[] args)
        {
            ErrorLog.Error(string.Format(message, args), exception);
        }

        public static void FatalError(string message)
        {
            FaralErrorLog.Fatal(message);
        }

        public static void FatalErrorFormat(string message, params object[] args)
        {
            FaralErrorLog.FatalFormat(message, args);
        }

        public static void FatalError(string message, Exception exception)
        {
            FaralErrorLog.Fatal(message, exception);
        }

        public static void FatalErrorFormat(string message, Exception exception, params object[] args)
        {
            FaralErrorLog.Fatal(string.Format(message, args), exception);
        }

        #endregion
    }
}