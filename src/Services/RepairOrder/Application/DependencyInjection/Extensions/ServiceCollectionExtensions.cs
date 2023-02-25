using Application.Abstractions;
using Application.Services;
using Application.UseCases.Commands;
using Application.UseCases.Events;
using Contracts.Services.RepairOrder;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        => services
            .AddScoped<IApplicationService, ApplicationService>();
    
    public static IServiceCollection AddCommandInteractors(this IServiceCollection services)
        => services
            .AddScoped<IInteractor<Command.CancelRepairOrder>, CancelRepairOrderInteractor>()
            .AddScoped<IInteractor<Command.CompleteRepairOrder>, CompleteRepairOrderInteractor>()
            .AddScoped<IInteractor<Command.PlaceRepairOrder>, PlaceRepairOrderInteractor>()
            .AddScoped<IInteractor<Command.ReopenRepairOrder>, ReopenRepairOrderInteractor>()
            .AddScoped<IInteractor<Command.StartRepairOrder>, StartRepairOrderInteractor>();


    public static IServiceCollection AddEventInteractors(this IServiceCollection services)
        => services
            .AddScoped<IPlaceRepairOrderWhenSchedulingRegisteredInteractor, PlaceRepairOrderWhenSchedulingRegisteredInteractor>();
}