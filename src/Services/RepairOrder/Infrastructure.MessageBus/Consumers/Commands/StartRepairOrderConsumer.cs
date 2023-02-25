using Application.Abstractions;
using Contracts.Services.RepairOrder;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers.Commands
{
    public class StartRepairOrderConsumer : Consumer<Command.StartRepairOrder>
    {
        public StartRepairOrderConsumer(IInteractor<Command.StartRepairOrder> interactor)
            : base(interactor) { }
    }
}
