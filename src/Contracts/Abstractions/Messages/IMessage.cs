namespace Contratos.Abstrações.Mensagens
{
    public interface IMessage
    {
        DateTimeOffset Timestamp { get; }
    }
}