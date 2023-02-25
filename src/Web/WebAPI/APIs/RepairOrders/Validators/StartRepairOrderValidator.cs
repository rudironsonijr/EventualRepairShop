using FluentValidation;

namespace WebAPI.APIs.RepairOrders.Validators;

public class StartRepairOrderValidator : AbstractValidator<Commands.StartRepairOrder>
{
    public StartRepairOrderValidator()
    {
        RuleFor(account => account.RepairOrderId)
            .NotNull()
            .NotEmpty();

        RuleFor(account => account.Notes)
            .NotNull()
            .NotEmpty();
    }
}