using Contratos.Abstrações.Mensagens;
using Domain.Abstractions.Entities;

namespace Domain.Abstractions.Aggregates
{
    public interface IAggregateRoot : IEntity
    {
        IEnumerable<IDomainEvent> UncommittedEvents { get; }
        void LoadFromHistory(IEnumerable<IDomainEvent> events);
        void Handle(ICommand command);
    }
}