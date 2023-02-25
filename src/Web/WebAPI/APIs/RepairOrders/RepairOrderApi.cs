using Asp.Versioning.Builder;
using WebAPI.Abstractions;

namespace WebAPI.APIs.RepairOrders;

public static class RepairOrderApi
{
    private const string BaseUrl = "/api/v{version:apiVersion}/repair-orders/";

    public static IVersionedEndpointRouteBuilder MapRepairOrderApiV1(this IVersionedEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup(BaseUrl).HasApiVersion(1);

        group.MapPut("/{repairOrderId:guid}/start", ([AsParameters] Commands.StartRepairOrder startRepairOrder)
            => ApplicationApi.SendCommandAsync(startRepairOrder));

        group.MapPut("/{repairOrderId:guid}/complete", ([AsParameters] Commands.CompleteRepairOrder completeRepairOrder)
            => ApplicationApi.SendCommandAsync(completeRepairOrder));

        group.MapPut("/{repairOrderId:guid}/cancel", ([AsParameters] Commands.CancelRepairOrder cancelRepairOrder)
            => ApplicationApi.SendCommandAsync(cancelRepairOrder));

        group.MapPut("/{repairOrderId:guid}/reopen", ([AsParameters] Commands.ReopenRepairOrder reopenRepairOrder)
            => ApplicationApi.SendCommandAsync(reopenRepairOrder));

        return builder;
    }
}