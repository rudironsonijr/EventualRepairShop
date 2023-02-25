using Contracts.Services.Workshop;
using Contratos.Abstrações.Mensagens;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Aggregates
{
    public class RepairOrder : AggregateRoot
    {
        private readonly List<Part> _parts = new();

        public Customer Customer { get; private set; }
        
        public RepairOrderStatus Status { get; private set; }

        public string Notes { get; private set; }

        public string Description { get; private set; }

        public DateTime ExpectedDueDate { get; private set; }

        public IEnumerable<Part> Parts
            => _parts.AsReadOnly();

        public override void Handle(ICommand command)
            => Handle(command as dynamic);




        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        private void When(DomainEvent.RepairOrderPlaced @event)
        {

        }
    }
}
