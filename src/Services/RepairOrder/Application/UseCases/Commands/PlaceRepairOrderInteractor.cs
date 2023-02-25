using Application.Abstractions;
using Application.Services;
using Contracts.Services.RepairOrder;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands
{
    public class PlaceRepairOrderInteractor : IInteractor<Command.PlaceRepairOrder>
    {
        private readonly IApplicationService _applicationService;

        public PlaceRepairOrderInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task InteractAsync(Command.PlaceRepairOrder command, CancellationToken cancellationToken)
        {
            RepairOrder repairOrder = new();
            repairOrder.Handle(command);
            await _applicationService.AppendEventsAsync(repairOrder, cancellationToken);
        }
    }
}
