using Contracts.Services.Sheduling;
using MassTransit;
using WebAPI.Abstractions;
using WebAPI.APIs.Schedulings.Validators;

namespace WebAPI.APIs.Schedulings;

public static class Commands
{
    public record RegisterScheduling(IBus Bus, Payloads.RegisterSchedulingPayload Payload, CancellationToken CancellationToken)
        : Validatable<RegisterSchedulingValidator>, ICommand<Command.RegisterScheduling>
    {
        public Command.RegisterScheduling Command => new(Payload.ScheduledDate, Payload.Customer, Payload.Device);
    }
}