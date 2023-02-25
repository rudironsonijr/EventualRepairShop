using Asp.Versioning.Builder;
using WebAPI.Abstractions;

namespace WebAPI.APIs.Schedulings;

public static class SchedulingApi
{
    private const string BaseUrl = "/api/v{version:apiVersion}/schedulings/";

    public static IVersionedEndpointRouteBuilder MapSchedulingApiV1(this IVersionedEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup(BaseUrl).HasApiVersion(1);

        group.MapPost("/", ([AsParameters] Commands.RegisterScheduling registerScheduling)
            => ApplicationApi.SendCommandAsync(registerScheduling));

        return builder;
    }
}