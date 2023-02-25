using Contracts.Abstractions.Messages;
using Contracts.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Scheduling
{
    public static class Command
    {
        public record RegisterScheduling(Guid SchedulingId, DateTime ScheduledDate, Dto.Customer Customer, Dto.Device Device, string Description) : Message, ICommand;
    }
}
