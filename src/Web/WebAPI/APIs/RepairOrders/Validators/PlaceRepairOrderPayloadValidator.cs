using Contracts.DataTransferObjects.Validators;
using FluentValidation;

namespace WebAPI.APIs.RepairOrders.Validators
{
    public class PlaceRepairOrderPayloadValidator : AbstractValidator<Payloads.PlaceRepairOrderPayload>
    {
        public PlaceRepairOrderPayloadValidator()
        {
            RuleFor(payload => payload.Customer)
                .SetValidator(new CustomerValidator())
                .OverridePropertyName(string.Empty);

            RuleFor(payload => payload.Device)
                .SetValidator(new DeviceValidator())
                .OverridePropertyName(string.Empty);

            RuleFor(payload => payload.Scheduling)
                .SetValidator(new SchedulingValidator())
                .OverridePropertyName(string.Empty);

            RuleFor(payload => payload.Description)
                .NotNull()
                .NotEmpty();
        }
    }
}
