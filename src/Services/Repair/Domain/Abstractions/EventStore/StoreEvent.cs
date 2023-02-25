using Contratos.Abstrações.Mensagens;
using Domain.Abstractions.Aggregates;

namespace Domain.Abstractions.EventStore;

public record StoreEvent(Guid AggregateId, string AggregateType, string EventType, IDomainEvent Event, long Version, DateTimeOffset Timestamp)
{
    public StoreEvent(IAggregateRoot aggregate, IDomainEvent @event)
        : this(aggregate.Id, aggregate.GetType().Name, @event.GetType().Name, @event, @event.Version, @event.Timestamp)
    { }
}