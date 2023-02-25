using Contracts.Abstractions.Messages;
using Contracts.Services.RepairOrder;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using Domain.Enumerations;
using Domain.ValueObjects;

namespace Domain.Aggregates
{
    public class RepairOrder : AggregateRoot
    {
        private readonly List<RepairOrderItem> _items = new();

        public Customer Customer { get; private set; }
        
        public Device Device { get; private set; }

        public Scheduling Scheduling { get; private set; }

        public string Description { get; private set; }

        public string Notes { get; private set; }

        public RepairOrderStatus Status { get; private set; }

        public IEnumerable<RepairOrderItem> Parts
            => _items.AsReadOnly();

        public override void Handle(ICommand command)
            => Handle(command as dynamic);

        private void Handle(Command.PlaceRepairOrder cmd)
            => RaiseEvent<DomainEvent.RepairOrderPlaced>(version
                => new(
                    Guid.NewGuid(),
                    Customer: cmd.Customer,
                    Device: cmd.Device,
                    Scheduling: cmd.Scheduling,
                    Description: cmd.Description,
                    Status: RepairOrderStatus.Confirmed,
                    version));

        private void Handle(Command.StartRepairOrder cmd)
            => RaiseEvent<DomainEvent.RepairOrderStarted>(version
                => new(
                    RepairOrderId: cmd.RepairOrderId,
                    Notes: cmd.Notes,
                    Status: RepairOrderStatus.Processing,
                    version));

        private void Handle(Command.CompleteRepairOrder cmd)
            => RaiseEvent<DomainEvent.RepairOrderCompleted>(version
                => new(
                    RepairOrderId: cmd.RepairOrderId,
                    Notes: cmd.Notes,
                    Status: RepairOrderStatus.Completed,
                    version));

        private void Handle(Command.CancelRepairOrder cmd)
            => RaiseEvent<DomainEvent.RepairOrderCanceled>(version
                => new(
                    RepairOrderId: cmd.RepairOrderId,
                    Notes: cmd.Notes,
                    Status: RepairOrderStatus.Canceled,
                    version));

        private void Handle(Command.ReopenRepairOrder cmd)
            => RaiseEvent<DomainEvent.RepairOrderCanceled>(version
                => new(
                    RepairOrderId: cmd.RepairOrderId,
                    Notes: cmd.Notes,
                    Status: RepairOrderStatus.Reopened,
                    version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        private void When(DomainEvent.RepairOrderPlaced @event)
        {
            (Id, Customer, Device, Scheduling, Description, Status, _) = @event;

        }

        private void When(DomainEvent.RepairOrderStarted @event)
        {
            Notes = @event.Notes;
            Status = @event.Status;
        }

        private void When(DomainEvent.RepairOrderCompleted @event)
        {
            Notes = @event.Notes;
            Status = @event.Status;
        }

        private void When(DomainEvent.RepairOrderCanceled @event)
        {
            Notes = @event.Notes;
            Status = @event.Status;
        }

        private void When(DomainEvent.RepairOrderReopened @event)
        {
            Notes = @event.Notes;
            Status = @event.Status;
        }
    }
}
