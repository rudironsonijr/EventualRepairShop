using Contracts.DataTransferObjects;

namespace WebAPI.APIs.Schedulings;

public static class Payloads
{
    public record RegisterSchedulingPayload(DateTime ScheduledDate, Dto.Customer Customer, Dto.Device Device, string Description);
}