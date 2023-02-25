namespace Contratos.Abstrações.Mensagens;

public interface IEvent : IMessage { }

public interface IVersionedEvent : IEvent
{
    long Version { get; }
}

public interface IDomainEvent : IVersionedEvent { }