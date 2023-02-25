using FluentValidation;

namespace WebAPI.APIs.RepairOrders.Validators;

public class CancelRepairOrderValidator : AbstractValidator<Commands.CancelRepairOrder>
{
    public CancelRepairOrderValidator()
    {
        RuleFor(account => account.RepairOrderId)
            .NotNull()
            .NotEmpty();

        RuleFor(account => account.Notes)
            .NotNull()
            .NotEmpty();
    }
}