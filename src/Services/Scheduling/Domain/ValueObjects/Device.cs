using Contracts.DataTransferObjects;

namespace Domain.ValueObjects
{
    public record Device(string Name, string Brand, string Type)
    {
        public static implicit operator Device(Dto.Device device)
            => new(device.Name, device.Brand, device.Type);
    }
}
