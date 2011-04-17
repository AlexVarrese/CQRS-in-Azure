using System;
using System.Diagnostics;

namespace Logging
{
    public class TraceLog : ILog
    {
        private readonly string key;

        public static readonly ILogProvider Provider = new DelegateLogProvider(s => new TraceLog(s));

        public TraceLog(string key)
        {
            this.key = key;
        }

        public void Write(LogLevel level, object message)
        {
            Trace.WriteLine(string.Format("[{0}]: {1,-5} - {2}", key, level, message));
            Trace.Flush();
        }
    }
}