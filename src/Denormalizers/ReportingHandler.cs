using System;

using Logging;

using Lokad.Cqrs.Feature.DefaultInterfaces;

using Messages.Events;

namespace Denormalizers
{
    public class ReportingHandler : IConsume<EventCreated>
    {
        private readonly ILog log;

        public ReportingHandler(ILogProvider provider)
        {
            log = provider.ForType<ReportingHandler>();
        }

        public void Consume(EventCreated message)
        {
            log.Info("Update reporting DB for {0}", message.Name);
        }
    }
}