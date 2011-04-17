using System;
using System.Globalization;

namespace Logging
{
    public static class ExtendILog
    {
        public static void Debug(this ILog log, object  message)
        {
            Write(log, LogLevel.Debug, message);
        }

        public static void Debug(this ILog log, Exception e, object message)
        {
            Write(log, LogLevel.Debug, message);
            Write(log, LogLevel.Debug, e);
        }

        public static void Debug(this ILog log, string format, params object[] args)
        {
            Write(log, LogLevel.Debug, format, args);
        }

        public static void Debug(this ILog log, Exception e, string format, params object[] args)
        {
            Write(log, LogLevel.Debug, format, args);
            Write(log, LogLevel.Debug, e);
        }

        public static void Info(this ILog log, object message)
        {
            Write(log, LogLevel.Info, message);
        }

        public static void Info(this ILog log, Exception e, object message)
        {
            Write(log, LogLevel.Info, message);
            Write(log, LogLevel.Info, e);
        }

        public static void Info(this ILog log, string format, params object[] args)
        {
            Write(log, LogLevel.Info, format, args);
        }

        public static void Info(this ILog log, Exception e, string format, params object[] args)
        {
            Write(log, LogLevel.Info, format, args);
            Write(log, LogLevel.Info, e);
        }

        public static void Warn(this ILog log, object message)
        {
            Write(log, LogLevel.Warn, message);
        }

        public static void Warn(this ILog log, Exception e, object message)
        {
            Write(log, LogLevel.Warn, message);
            Write(log, LogLevel.Warn, e);
        }

        public static void Warn(this ILog log, string format, params object[] args)
        {
            Write(log, LogLevel.Warn, format, args);
        }

        public static void Warn(this ILog log, Exception e, string format, params object[] args)
        {
            Write(log, LogLevel.Warn, format, args);
            Write(log, LogLevel.Warn, e);
        }

        public static void Error(this ILog log, object message)
        {
            Write(log, LogLevel.Error, message);
        }

        public static void Error(this ILog log, Exception e, object message)
        {
            Write(log, LogLevel.Error, message);
            Write(log, LogLevel.Error, e);
        }

        public static void Error(this ILog log, string format, params object[] args)
        {
            Write(log, LogLevel.Error, format, args);
        }

        public static void Error(this ILog log, Exception e, string format, params object[] args)
        {
            Write(log, LogLevel.Error, format, args);
            Write(log, LogLevel.Error, e);
        }

        public static void Fatal(this ILog log, object message)
        {
            Write(log, LogLevel.Fatal, message);
        }

        public static void Fatal(this ILog log, Exception e, object message)
        {
            Write(log, LogLevel.Fatal, message);
            Write(log, LogLevel.Fatal, e);
        }

        public static void Fatal(this ILog log, string format, params object[] args)
        {
            Write(log, LogLevel.Fatal, format, args);
        }

        public static void Fatal(this ILog log, Exception e, string format, params object[] args)
        {
            Write(log, LogLevel.Fatal, format, args);
            Write(log, LogLevel.Fatal, e);
        }

        private static void Write(ILog log, LogLevel level, object message)
        {
            log.Write(level, message);
        }

        private static void Write(ILog log, LogLevel level, string format, params object[] args)
        {
            log.Write(level, string.Format(CultureInfo.CurrentCulture, format, args));
        }
    }
}