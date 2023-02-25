using Contracts.DataTransferObjects;

namespace WebAPI.APIs.RepairOrders;

public static class Payloads
{
    public record PlaceRepairOrderPayload(
        Dto.Customer Customer,
        Dto.Device Device,
        Dto.Scheduling Scheduling,
        string Description);
}