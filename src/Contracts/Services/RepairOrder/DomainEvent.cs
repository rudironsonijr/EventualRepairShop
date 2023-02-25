using Contracts.Abstractions.Messages;
using Contracts.DataTransferObjects;

namespace Contracts.Services.RepairOrder
{
    public class DomainEvent
    {
        public record RepairOrderPlaced(
            Guid RepairOrderId,
            Dto.Customer Customer,
            Dto.Device Device,
            Dto.Scheduling Scheduling,
            string Description,
            string Status,
            long Version) : Message, IDomainEvent;

        public record RepairOrderStarted(
            Guid RepairOrderId,
            string Notes,
            string Status,
            long Version) : Message, IDomainEvent;

        public record RepairOrderCompleted(
            Guid RepairOrderId,
            string Notes,
            string Status,
            long Version) : Message, IDomainEvent;

        public record RepairOrderCanceled(
            Guid RepairOrderId,
            string Notes,
            string Status,
            long Version) : Message, IDomainEvent;

        public record RepairOrderReopened(
            Guid RepairOrderId,
            string Notes,
            string Status,
            long Version) : Message, IDomainEvent;
    }
}
