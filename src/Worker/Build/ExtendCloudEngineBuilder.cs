using Logging;

using Lokad.Cqrs.Build.Engine;

using Autofac;

namespace Worker.Build
{
    public static class ExtendCloudEngineBuilder
    {
        public static CloudEngineBuilder ConfigureEventStore(this CloudEngineBuilder builder)
        {
            var module = new EventStoreModule();

            builder.Builder.RegisterModule(module);

            return builder;
        }

        public static CloudEngineBuilder ConfigureLogger(this CloudEngineBuilder builder, ILogProvider provider)
        {
            var module = new LoggingModule {Provider = provider};

            builder.Builder.RegisterModule(module);
            
            return builder;
        }
    }
}