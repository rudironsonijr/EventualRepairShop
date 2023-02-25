using System.Runtime.CompilerServices;
using Application.Abstractions.Gateways;
using Domain.Abstractions.Aggregates;
using Domain.Abstractions.EventStore;
using Infrastructure.EventStore.DependencyInjection.Options;
using Infrastructure.EventStore.Exceptions;
using Microsoft.Extensions.Options;

namespace Infrastructure.EventStore
{
    public class EventStoreGateway : IEventStoreGateway
    {
        private readonly IEventStoreRepository _repository;

        public EventStoreGateway(IEventStoreRepository repository)
        {
            _repository = repository;
        }

        public async Task AppendEventsAsync(IAggregateRoot aggregate, CancellationToken cancellationToken)
        {
            foreach (var @event in aggregate.UncommittedEvents.Select(@event => StoreEvent.Create(aggregate, @event)))
            {
                await _repository.AppendEventAsync(@event, cancellationToken);
            }
        }

        public async Task<TAggregate> LoadAggregateAsync<TAggregate>(Guid aggregateId, CancellationToken cancellationToken)
            where TAggregate : IAggregateRoot, new()
        {
            var events = await _repository.GetStreamAsync(aggregateId, null, cancellationToken);

            var aggregate = new TAggregate();
            aggregate.LoadFromHistory(events);

            return aggregate;
        }

        public ConfiguredCancelableAsyncEnumerable<Guid> StreamAggregatesId(CancellationToken cancellationToken)
            => _repository.StreamAggregatesId(cancellationToken);

        public Task ExecuteTransactionAsync(Func<CancellationToken, Task> operationAsync, CancellationToken cancellationToken)
            => _repository.ExecuteTransactionAsync(operationAsync, cancellationToken);
    }
}