using Application.Abstractions;
using Contracts.Services.RepairOrder;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers.Commands
{
    public class ReopenRepairOrderConsumer : Consumer<Command.ReopenRepairOrder>
    {
        public ReopenRepairOrderConsumer(IInteractor<Command.ReopenRepairOrder> interactor)
            : base(interactor) { }
    }
}
