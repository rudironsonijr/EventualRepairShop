using Application.Abstractions;
using Application.Services;
using Domain.Aggregates;
using Scheduling = Contracts.Services.Scheduling;
using Contracts.Services.RepairOrder;
using Contracts.DataTransferObjects;

namespace Application.UseCases.Events
{
    public interface IPlaceRepairOrderWhenSchedulingRegisteredInteractor : IInteractor<Scheduling.DomainEvent.SchedulingRegistered> { }

    public class PlaceRepairOrderWhenSchedulingRegisteredInteractor : IPlaceRepairOrderWhenSchedulingRegisteredInteractor
    {
        private readonly IApplicationService _applicationService;

        public PlaceRepairOrderWhenSchedulingRegisteredInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task InteractAsync(Scheduling.DomainEvent.SchedulingRegistered @event, CancellationToken cancellationToken)
        {
            RepairOrder repairOrder = new();

            var command = new Command.PlaceRepairOrder(
                RepairOrderId: Guid.NewGuid(),
                Customer: @event.Customer,
                Device: @event.Device,
                Scheduling: (Dto.Scheduling)@event.ScheduledDate,
                Description: @event.Description);

            repairOrder.Handle(command);

            await _applicationService.AppendEventsAsync(repairOrder, cancellationToken);
        }
    }
}