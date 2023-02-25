using Application.Abstractions;
using Application.Services;
using Contracts.Services.Scheduling;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands
{
    public class RegisterSchedulingInteractor : IInteractor<Command.RegisterScheduling>
    {
        private readonly IApplicationService _applicationService;

        public RegisterSchedulingInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task InteractAsync(Command.RegisterScheduling command, CancellationToken cancellationToken)
        {
            Scheduling scheduling = new();
            scheduling.Handle(command);
            await _applicationService.AppendEventsAsync(scheduling, cancellationToken);
        }
    }
}
