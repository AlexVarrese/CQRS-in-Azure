using System;

using CommonDomain.Core;

using Lokad.Cqrs.Feature.DefaultInterfaces;

using Messages.Events;

namespace DomainModel
{
    public class Event : AggregateBase<IMessage>
    {
        private DateTime lastModified;
        private EventName name;

        private Event(Guid id)
        {
            Id = id;
        }

        public Event(Guid id, EventName name) : this(id)
        {
            this.name = name;

            RaiseEvent(new EventCreated
            {
                EventId = id,
                Name = name.Name,
                CreationDate = DateTime.UtcNow
            });
        }

        public static Event CreateEvent(Guid id, string name)
        {
            return new Event(id, new EventName(name));
        }

        protected void Apply(EventCreated e)
        {
            lastModified = e.CreationDate;
        }
    }

    public class EventName
    {
        public EventName(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
