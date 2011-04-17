using Autofac;
using Autofac.Core;

using Logging;

namespace Worker.Build
{
    public class LoggingModule : IModule
    {
        private readonly ContainerBuilder builder = new ContainerBuilder();

        public LoggingModule()
        {
            Provider = NullLog.Provider;
        }

        void IModule.Configure(IComponentRegistry componentRegistry)
        {
            builder.RegisterInstance(Provider).SingleInstance().As<ILogProvider>();

            builder.Update(componentRegistry);
        }

        public ILogProvider Provider { get; set; }
    }
}