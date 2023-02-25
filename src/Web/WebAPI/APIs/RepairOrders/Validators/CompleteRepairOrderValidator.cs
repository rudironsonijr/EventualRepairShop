using FluentValidation;

namespace WebAPI.APIs.RepairOrders.Validators;

public class CompleteRepairOrderValidator : AbstractValidator<Commands.CompleteRepairOrder>
{
    public CompleteRepairOrderValidator()
    {
        RuleFor(account => account.RepairOrderId)
            .NotNull()
            .NotEmpty();

        RuleFor(account => account.Notes)
            .NotNull()
            .NotEmpty();
    }
}