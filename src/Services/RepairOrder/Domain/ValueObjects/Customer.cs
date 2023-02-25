using Contracts.DataTransferObjects;

namespace Domain.ValueObjects
{
    public record Customer(string Name, string PhoneNumber)
    {
        public static implicit operator Customer(Dto.Customer customer)
            => new(customer.Name, customer.PhoneNumber);
    }
}
