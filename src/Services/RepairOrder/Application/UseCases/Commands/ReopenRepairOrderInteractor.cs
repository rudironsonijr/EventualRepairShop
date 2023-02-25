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
    public class ReopenRepairOrderInteractor : IInteractor<Command.ReopenRepairOrder>
    {
        private readonly IApplicationService _applicationService;

        public ReopenRepairOrderInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task InteractAsync(Command.ReopenRepairOrder command, CancellationToken cancellationToken)
        {
            var repairOrder = await _applicationService.LoadAggregateAsync<RepairOrder>(command.RepairOrderId, cancellationToken);
            repairOrder.Handle(command);
            await _applicationService.AppendEventsAsync(repairOrder, cancellationToken);
        }
    }
}
