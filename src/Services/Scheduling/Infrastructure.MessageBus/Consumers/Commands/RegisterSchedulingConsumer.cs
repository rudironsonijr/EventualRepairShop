using Application.Abstractions;
using Contracts.Services.Scheduling;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers.Commands
{
    public class RegisterSchedulingConsumer : Consumer<Command.RegisterScheduling>
    {
        public RegisterSchedulingConsumer(IInteractor<Command.RegisterScheduling> interactor)
            : base(interactor) { }
    }
}
