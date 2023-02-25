using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataTransferObjects.Validators
{
    public class SchedulingValidator : AbstractValidator<Dto.Scheduling>
    {
        public SchedulingValidator()
        {
            RuleFor(scheduling => scheduling.ScheduledStart)
                .Must(BeAValidDate)
                .WithMessage("Scheduled Date is required.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
