using AppService;

using Autofac;
using Autofac.Core;

using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;

using Lokad.Cqrs;

using EventStore;
using EventStore.Dispatcher;

using System.Linq;

namespace Worker.Build
{
    public class EventStoreModule : IModule
    {
        private readonly ContainerBuilder builder = new ContainerBuilder();

        void IModule.Configure(IComponentRegistry componentRegistry)
        {
            builder.Register(ComposeEventStore)
                .SingleInstance()
                .As<IStoreEvents>();

            builder.RegisterType<ConflictDetector>().As<IDetectConflicts>();
            builder.RegisterType<EventStoreRepository>().As<IRepository>();
            builder.RegisterType<AggregateFactory>().As<IConstructAggregates>();

            builder.Update(componentRegistry);
        }

        private static IStoreEvents ComposeEventStore(IComponentContext context)
        {
            var scope = context.Resolve<ILifetimeScope>();

            var publisher = new DelegateMessagePublisher(commit=> DispatchCommit(scope, commit));

            var store = Wireup.Init()
                .UsingSqlAzurePersistence("EventStoreConnectionString")
                .InitializeStorageEngine()
                .UsingJsonSerialization()
                .Compress()
                .UsingAsynchronousDispatcher()
                .PublishTo(publisher)
                .Build();

            return store;
        }

        private static void DispatchCommit(ILifetimeScope scope, Commit commit)
        {
            var sender = scope.Resolve<IMessageSender>();

            var events = commit.Events.Select(e=>e.Body).ToArray();

            sender.SendAsBatch(events);
        }
    }
}