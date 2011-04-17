using System;

using CommonDomain.Persistence;

using DomainModel;

using Lokad.Cqrs.Feature.DefaultInterfaces;

using Messages.Commands;

namespace AppService
{
    public class CreateEventHandler : IConsume<CreateEvent>
    {
        private readonly IRepository repository;

        public CreateEventHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public void Consume(CreateEvent message)
        {
            var e = Event.CreateEvent(Guid.NewGuid(), message.Name);

            repository.Save(e, Guid.NewGuid(), null);
        }
    }
}
