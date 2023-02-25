using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Workshop
{
    public class DomainEvent
    {
        public record RepairOrderPlaced(Guid RepairOrderId);

        public record RepairOrderStarted(Guid RepairOrderId);

        public record RepairOrderCanceled(Guid RepairOrderId);

        public record RepairOrderCompleted(Guid RepairOrderId);

        public record RepairOrderReopened(Guid RepairOrderId);
    }
}
