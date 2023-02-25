using FluentValidation;

namespace WebAPI.APIs.Schedulings.Validators;

public class RegisterSchedulingValidator : AbstractValidator<Commands.RegisterScheduling>
{
    public RegisterSchedulingValidator()
    {
        RuleFor(scheduling => scheduling.Payload)
            .SetValidator(new RegisterSchedulingPayloadValidator())
            .NotEmpty();
    }
}