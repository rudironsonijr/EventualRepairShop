using Contracts.Abstractions.Messages;
using Contracts.DataTransferObjects;

namespace Contracts.Services.RepairOrder
{
    public class Command
    {
        public record PlaceRepairOrder(
            Dto.Customer Customer,
            Dto.Device Device,
            Dto.Scheduling Scheduling,
            string Description) : Message, ICommand;

        public record StartRepairOrder(
            Guid RepairOrderId, 
            string Notes) : Message, ICommand;

        public record CompleteRepairOrder(
            Guid RepairOrderId,
            string Notes) : Message, ICommand;

        public record CancelRepairOrder(
            Guid RepairOrderId,
            string Notes) : Message, ICommand;

        public record ReopenRepairOrder(
            Guid RepairOrderId,
            string Notes) : Message, ICommand;
    }
}
