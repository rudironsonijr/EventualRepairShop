using Application.Abstractions;
using Contracts.Services.RepairOrder;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers.Commands
{
    public class CancelRepairOrderConsumer : Consumer<Command.CancelRepairOrder>
    {
        public CancelRepairOrderConsumer(IInteractor<Command.CancelRepairOrder> interactor)
            : base(interactor) { }
    }
}
