namespace Contracts.Abstractions.Messages
{
    public abstract record Message : IMessage
    {
        public DateTimeOffset Timestamp { get; private init; } = DateTimeOffset.Now;
    }

}