namespace Logging
{
    public class NullLog : ILog
    {
        public static readonly ILogProvider Provider = new DelegateLogProvider(s => new NullLog());

        public void Write(LogLevel level, object message)
        {}
    }
}