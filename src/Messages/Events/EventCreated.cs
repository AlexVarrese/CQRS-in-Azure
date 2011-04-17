using System;

using Lokad.Cqrs.Feature.DefaultInterfaces;

using ProtoBuf;

namespace Messages.Events
{
    [ProtoContract]
    public class EventCreated : IMessage
    {
        [ProtoMember(1)]
        public Guid EventId { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public DateTime CreationDate { get; set; }
    }
}