using Domain.Abstractions.Entities;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class RepairOrderItem : Entity
    {
        public Part Part { get; }

        public int Quantity { get; }

        public RepairOrderItem(Guid id, Part part, int quantity)
        {
            Id = id;
            Part = part;
            Quantity = quantity;
        }
    }
}
