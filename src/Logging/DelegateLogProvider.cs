using System;

namespace Logging
{
    class DelegateLogProvider : ILogProvider
    {
        private readonly Func<string, ILog> keyGen;

        public DelegateLogProvider(Func<string, ILog> keyGen)
        {
            this.keyGen = keyGen;
        }

        public ILog Create(string key)
        {
            return keyGen(key);
        }
    }
}