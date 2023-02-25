using Contracts.DataTransferObjects;

namespace Domain.ValueObjects
{
    public record Customer(
            string FirstName,
            string LastName,
            DateOnly? Birthdate,
            string Gender,
            string PhoneNumber,
            string Email)
    {
        public static implicit operator Customer(Dto.Customer customer)
            => new(
                FirstName: customer.FirstName,
                LastName: customer.LastName,
                Birthdate: customer.Birthdate,
                Gender: customer.Gender,
                PhoneNumber: customer.PhoneNumber,
                Email: customer.Email);
    }
}
