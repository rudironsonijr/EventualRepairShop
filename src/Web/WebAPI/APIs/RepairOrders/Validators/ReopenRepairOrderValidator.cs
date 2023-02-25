using FluentValidation;

namespace WebAPI.APIs.RepairOrders.Validators;

public class ReopenRepairOrderValidator : AbstractValidator<Commands.ReopenRepairOrder>
{
    public ReopenRepairOrderValidator()
    {
        RuleFor(account => account.RepairOrderId)
            .NotNull()
            .NotEmpty();

        RuleFor(account => account.Notes)
            .NotNull()
            .NotEmpty();
    }
}