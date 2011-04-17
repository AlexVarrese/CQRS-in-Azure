using System;
using System.Net;

using AppService;

using Denormalizers;

using Logging;

using Lokad.Cqrs.Build;
using Lokad.Cqrs.Build.Engine;
using Lokad.Cqrs.Core.Dispatch;
using Lokad.Cqrs.Feature.Logging;

using Messages.Commands;
using Messages.Events;

using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

using Worker.Build;

namespace Worker
{
    public class WorkerRole : CloudEngineRole
    {
        public override bool OnStart()
        {
            DiagnosticMonitor.Start("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString");

            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }

        protected override CloudEngineHost BuildHost()
        {
            var builder = new CloudEngineBuilder();

            builder.Serialization.UseProtoBufMessageSerializer();

            builder.Azure.LoadStorageAccountFromSettings(
                () => new CloudSettingsProvider().GetString("StorageConnectionString")
                          .ExposeException("StorageConnectionString was not found in the role configuration.")
                );
            
            builder.DomainIs(d =>
            {
                d.WithDefaultInterfaces();
                d.InAssemblyOf<CreateEvent, CreateEventHandler>();
                d.InAssemblyOf<EventCreated, EventCreatedHandler>();
            });

            builder.AddMessageClient(c => c.DefaultToQueue("messages"));

            builder.AddMessageHandler(x =>
            {
                x.ListenToQueue("messages");
                x.Dispatch<DispatchEventToMultipleConsumers>();
            });

            builder.ConfigureEventStore();

            builder.Logging.RegisterLogProvider(new SystemObserver());
            
            builder.ConfigureLogger(TraceLog.Provider);

            return builder.Build();
        }
    }
}