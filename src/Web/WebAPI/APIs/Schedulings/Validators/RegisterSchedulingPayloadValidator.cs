using Contracts.DataTransferObjects.Validators;
using FluentValidation;

namespace WebAPI.APIs.Schedulings.Validators
{
    public class RegisterSchedulingPayloadValidator : AbstractValidator<Payloads.RegisterSchedulingPayload>
    {
        public RegisterSchedulingPayloadValidator()
        {
            RuleFor(payload => payload.ScheduledDate)
                .Must(BeAValidDate)
                .WithMessage("Scheduled Date is required.");

            RuleFor(payload => payload.Customer)
                .SetValidator(new CustomerValidator())
                .OverridePropertyName(string.Empty);

            RuleFor(payload => payload.Device)
                .SetValidator(new DeviceValidator())
                .OverridePropertyName(string.Empty);
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
