using Contracts.Abstractions.Messages;
using Domain.Abstractions.Entities;

namespace Domain.Abstractions.Aggregates
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        public long Version { get; private set; }

        private readonly List<IDomainEvent> _events = new();
        
        public IEnumerable<IDomainEvent> UncommittedEvents
            => _events.AsReadOnly();

        public void LoadFromHistory(IEnumerable<IDomainEvent> events)
        {
            foreach (var @event in events)
            {
                Apply(@event);
                Version = @event.Version;
            }
        }

        public abstract void Handle(ICommand command);

        protected void RaiseEvent<TEvent>(Func<long, TEvent> func) where TEvent : IDomainEvent
            => RaiseEvent((func as Func<long, IDomainEvent>)!);

        protected void RaiseEvent(Func<long, IDomainEvent> onRaise)
        {
            Version++;
            var @event = onRaise(Version);
            Apply(@event);
            _events.Add(@event);
        }

        protected abstract void Apply(IDomainEvent @event);

    }
}
