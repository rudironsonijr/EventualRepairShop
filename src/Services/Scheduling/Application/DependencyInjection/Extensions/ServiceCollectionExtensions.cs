using Application.Abstractions;
using Application.Services;
using Application.UseCases.Commands;
using Contracts.Services.Scheduling;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        => services
            .AddScoped<IApplicationService, ApplicationService>();
    
    public static IServiceCollection AddCommandInteractors(this IServiceCollection services)
        => services
            .AddScoped<IInteractor<Command.RegisterScheduling>, RegisterSchedulingInteractor>();

    //public static IServiceCollection AddEventInteractors(this IServiceCollection services)
    //    => services
    //        .AddScoped<IPlaceRepairOrderWhenSchedulingRegisteredInteractor, PlaceRepairOrderWhenSchedulingRegisteredInteractor>();
}