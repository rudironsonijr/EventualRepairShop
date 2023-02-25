using Contracts.Abstractions.Messages;
using Contracts.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Sheduling
{
    public static class Command
    {
        public record RegisterScheduling(DateTime ScheduledDate, Dto.Customer Customer, Dto.Device Device) : Message, ICommand;
    }
}
