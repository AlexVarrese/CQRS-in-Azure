using Logging;

using Lokad.Cqrs.Feature.DefaultInterfaces;

using Messages.Events;

namespace Denormalizers
{
    public class EventCreatedHandler : IConsume<EventCreated>
    {
        private readonly ILog log;

        public EventCreatedHandler(ILogProvider provider)
        {
            log = provider.ForType<EventCreatedHandler>();
        }

        public void Consume(EventCreated message)
        {
            log.Debug("event created: {0}", message.Name);
        }
    }
}
