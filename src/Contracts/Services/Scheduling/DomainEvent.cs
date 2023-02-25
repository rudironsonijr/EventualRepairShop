using Contracts.Abstractions.Messages;
using Contracts.DataTransferObjects;

namespace Contracts.Services.Scheduling
{
    public static class DomainEvent
    {
        public record SchedulingRegistered(Guid SchedulingId, DateTime ScheduledDate, Dto.Customer Customer, Dto.Device Device, string Description, long Version) : Message, IDomainEvent;
    }
}
