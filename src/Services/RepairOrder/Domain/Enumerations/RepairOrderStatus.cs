using Ardalis.SmartEnum;
using Domain.Entities;

namespace Domain.Enumerations
{
    public class RepairOrderStatus : SmartEnum<RepairOrderStatus>
    {
        public RepairOrderStatus(string name, int value)
            : base(name, value) { }

        public static readonly RepairOrderStatus Confirmed = new(nameof(Confirmed), 1);
        public static readonly RepairOrderStatus Failed = new(nameof(Failed), 3);
        public static readonly RepairOrderStatus Processing = new(nameof(Processing), 4);
        public static readonly RepairOrderStatus Completed = new(nameof(Completed), 5);
        public static readonly RepairOrderStatus OnHold = new(nameof(OnHold), 6);
        public static readonly RepairOrderStatus Canceled = new(nameof(Canceled), 7);
        public static readonly RepairOrderStatus Reopened = new(nameof(Reopened), 8);

        public static implicit operator RepairOrderStatus(string name)
            => FromName(name);

        public static implicit operator RepairOrderStatus(int value)
            => FromValue(value);

        public static implicit operator string(RepairOrderStatus status)
            => status.Name;

        public static implicit operator int(RepairOrderStatus status)
            => status.Value;
    }
}
