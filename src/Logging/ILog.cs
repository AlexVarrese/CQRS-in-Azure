using System;

namespace Logging
{
    public interface ILog
    {
        void Write(LogLevel level, object message);
    }
}