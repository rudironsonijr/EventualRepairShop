using Application.Abstractions;
using Contracts.Services.RepairOrder;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers.Commands
{
    public class PlaceRepairOrderConsumer : Consumer<Command.PlaceRepairOrder>
    {
        public PlaceRepairOrderConsumer(IInteractor<Command.PlaceRepairOrder> interactor)
            : base(interactor) { }
    }
}
