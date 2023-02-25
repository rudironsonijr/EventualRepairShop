namespace Contratos.Abstrações.Mensagens
{

    public abstract record Message : IMessage
    {
        public DateTimeOffset Timestamp { get; private init; } = DateTimeOffset.Now;
    }

}