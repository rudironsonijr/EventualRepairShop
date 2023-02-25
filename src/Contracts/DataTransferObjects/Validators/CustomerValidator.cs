using Contracts.Enumerations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataTransferObjects.Validators
{
    public class CustomerValidator : AbstractValidator<Dto.Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Email)
                .EmailAddress();

            RuleFor(customer => customer.FirstName)
                .Length(5, 50)
                .NotEqual(customer => customer.LastName, StringComparer.OrdinalIgnoreCase);

            RuleFor(customer => customer.LastName)
                .Length(5, 50)
                .MaximumLength(50);

            RuleFor(customer => customer.Birthdate)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTimeOffset.Now.AddYears(-18).DateTime));

            RuleFor(customer => customer.Gender)
                .Must(gender => Gender.TryFromName(gender, out _));


        }
    }
}
