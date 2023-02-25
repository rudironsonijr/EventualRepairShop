using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataTransferObjects.Validators
{
    public class DeviceValidator : AbstractValidator<Dto.Device>
    {
        public DeviceValidator()
        {
            RuleFor(device => device.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(device => device.Brand)
                .NotNull()
                .NotEmpty();

            RuleFor(device => device.Type)
                .NotNull()
                .NotEmpty();
        }
    }
}
