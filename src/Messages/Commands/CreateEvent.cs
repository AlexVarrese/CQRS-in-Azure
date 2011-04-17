using System;

using Lokad.Cqrs.Feature.DefaultInterfaces;

using ProtoBuf;

namespace Messages.Commands
{
    [ProtoContract]
    public class CreateEvent : IMessage
    {
        [ProtoMember(1)]
        public Guid EventId { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }
    }
}
