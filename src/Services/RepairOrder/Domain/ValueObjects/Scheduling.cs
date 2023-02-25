using Contracts.DataTransferObjects;

namespace Domain.ValueObjects
{
    public record Scheduling(DateTime ScheduledStart)
    {
        public static implicit operator Scheduling(Dto.Scheduling scheduling)
            => new(scheduling.ScheduledStart);

        public static implicit operator Scheduling(DateTime scheduledStart)
            => new(scheduledStart);
    }
}
