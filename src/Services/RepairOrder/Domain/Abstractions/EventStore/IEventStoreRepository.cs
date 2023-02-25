using Contracts.Abstractions.Messages;
using System.Runtime.CompilerServices;

namespace Domain.Abstractions.EventStore;

public interface IEventStoreRepository
{
    Task AppendEventAsync(StoreEvent storeEvent, CancellationToken cancellationToken);
    Task<List<IDomainEvent>> GetStreamAsync(Guid aggregateId, long? version, CancellationToken cancellationToken);
    ConfiguredCancelableAsyncEnumerable<Guid> StreamAggregatesId(CancellationToken cancellationToken);
    Task ExecuteTransactionAsync(Func<CancellationToken, Task> operationAsync, CancellationToken cancellationToken);
}