using Application.Abstractions;
using Contracts.Services.RepairOrder;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers.Commands
{
    public class CompleteRepairOrderConsumer : Consumer<Command.CompleteRepairOrder>
    {
        public CompleteRepairOrderConsumer(IInteractor<Command.CompleteRepairOrder> interactor)
            : base(interactor) { }
    }
}
