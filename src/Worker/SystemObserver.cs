using System.Diagnostics;

using Lokad.Cqrs;
using Lokad.Cqrs.Feature.AzureConsumer.Events;

namespace Worker
{
    public class SystemObserver : ISystemObserver
    {
        public void Notify(ISystemEvent @event)
        {
            if(@event is FailedToConsumeMessage)
            {
                Notify((FailedToConsumeMessage)@event);
                return;
            }

            if (@event is FailedToDeserializeMessage)
            {
                Notify((FailedToDeserializeMessage)@event);
                return;
            }

            Trace.WriteLine(@event);
            Trace.Flush();
        }

        public void Notify(FailedToDeserializeMessage message)
        {
            Trace.WriteLine("Failed to deserialize message.");
            Trace.WriteLine(message.Exception);
        }

        public void Notify(FailedToConsumeMessage message)
        {
            Trace.WriteLine("Failed to consume message.");
            Trace.WriteLine(message.Exception);
        }
    }
}