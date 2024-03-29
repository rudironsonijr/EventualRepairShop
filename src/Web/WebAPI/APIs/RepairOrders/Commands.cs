﻿using Contracts.Services.RepairOrder;
using MassTransit;
using WebAPI.Abstractions;
using WebAPI.APIs.RepairOrders.Validators;
using WebAPI.APIs.Schedulings;

namespace WebAPI.APIs.RepairOrders;

public static class Commands
{
    public record PlaceRepairOrder(IBus Bus, Payloads.PlaceRepairOrderPayload Payload, CancellationToken CancellationToken)
        : Validatable<PlaceRepairOrderValidator>, ICommand<Command.PlaceRepairOrder>
    {
        public Command.PlaceRepairOrder Command => new(Guid.NewGuid(), Payload.Customer, Payload.Device, Payload.Scheduling, Payload.Description);
    }

    public record StartRepairOrder(IBus Bus, Guid RepairOrderId, string Notes, CancellationToken CancellationToken)
        : Validatable<StartRepairOrderValidator>, ICommand<Command.StartRepairOrder>
    {
        public Command.StartRepairOrder Command => new(RepairOrderId, Notes);
    }

    public record CompleteRepairOrder(IBus Bus, Guid RepairOrderId, string Notes, CancellationToken CancellationToken)
        : Validatable<CompleteRepairOrderValidator>, ICommand<Command.CompleteRepairOrder>
    {
        public Command.CompleteRepairOrder Command => new(RepairOrderId, Notes);
    }

    public record CancelRepairOrder(IBus Bus, Guid RepairOrderId, string Notes, CancellationToken CancellationToken)
        : Validatable<CancelRepairOrderValidator>, ICommand<Command.CancelRepairOrder>
    {
        public Command.CancelRepairOrder Command => new(RepairOrderId, Notes);
    }

    public record ReopenRepairOrder(IBus Bus, Guid RepairOrderId, string Notes, CancellationToken CancellationToken)
        : Validatable<ReopenRepairOrderValidator>, ICommand<Command.ReopenRepairOrder>
    {
        public Command.ReopenRepairOrder Command => new(RepairOrderId, Notes);
    }
}