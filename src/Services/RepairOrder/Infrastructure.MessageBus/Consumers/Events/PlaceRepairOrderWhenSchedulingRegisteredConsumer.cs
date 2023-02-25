using Application.UseCases.Events;
using MassTransit;
using Scheduling = Contracts.Services.Scheduling;

namespace Infrastructure.MessageBus.Consumers.Events;

public class PlaceRepairOrderWhenSchedulingRegisteredConsumer : IConsumer<Scheduling.DomainEvent.SchedulingRegistered>
{
    private readonly IPlaceRepairOrderWhenSchedulingRegisteredInteractor _interactor;

    public PlaceRepairOrderWhenSchedulingRegisteredConsumer(IPlaceRepairOrderWhenSchedulingRegisteredInteractor interactor)
    {
        _interactor = interactor;
    }

    public Task Consume(ConsumeContext<Scheduling.DomainEvent.SchedulingRegistered> context)
        => _interactor.InteractAsync(context.Message, context.CancellationToken);
}