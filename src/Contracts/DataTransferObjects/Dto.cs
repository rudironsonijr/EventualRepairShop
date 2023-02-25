namespace Contracts.DataTransferObjects
{
    public static class Dto
    {
        public record Customer(string Name, string PhoneNumber);

        public record Device(string Name, string Brand, string Type);

        public record Part(string Name, string Brand);

        public record Scheduling(DateTime ScheduledStart);
    }
}
