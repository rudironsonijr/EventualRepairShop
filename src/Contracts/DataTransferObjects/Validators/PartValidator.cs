using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataTransferObjects.Validators
{
    public class PartValidator : AbstractValidator<Dto.Part>
    {
        public PartValidator()
        {
            RuleFor(part => part.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(part => part.Brand)
                .NotNull()
                .NotEmpty();

        }
    }
}
