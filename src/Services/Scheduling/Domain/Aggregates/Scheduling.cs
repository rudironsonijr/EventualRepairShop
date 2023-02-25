using Contracts.Abstractions.Messages;
using Contracts.Services.Scheduling;
using Domain.Abstractions.Aggregates;

using Domain.ValueObjects;

namespace Domain.Aggregates
{
    public class Scheduling : AggregateRoot
    {
        public Customer Customer { get; private set; }
        
        public Device Device { get; private set; }

        public DateTime ScheduledDate { get; private set; }

        public string Description { get; private set; }

        public override void Handle(ICommand command)
            => Handle(command as dynamic);

        private void Handle(Command.RegisterScheduling cmd)
            => RaiseEvent<DomainEvent.SchedulingRegistered>(version
                => new(
                    SchedulingId: cmd.SchedulingId,
                    ScheduledDate: cmd.ScheduledDate,
                    Customer: cmd.Customer,
                    Device: cmd.Device,
                    Description: cmd.Description,
                    version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        private void When(DomainEvent.SchedulingRegistered @event)
        {
            (Id, ScheduledDate, Customer, Device, Description, _) = @event;
        }
    }
}
