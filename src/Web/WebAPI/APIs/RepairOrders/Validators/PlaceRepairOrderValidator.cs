using FluentValidation;
using WebAPI.APIs.Schedulings.Validators;

namespace WebAPI.APIs.RepairOrders.Validators
{
    public class PlaceRepairOrderValidator : AbstractValidator<Commands.PlaceRepairOrder>
    {
        public PlaceRepairOrderValidator()
        {
            RuleFor(repairOrder => repairOrder.Payload)
                .SetValidator(new PlaceRepairOrderPayloadValidator())
                .NotEmpty();
        }
    }
}
