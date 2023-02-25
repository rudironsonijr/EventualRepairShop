using System.Runtime.CompilerServices;
using Contratos.Abstrações.Mensagens;
using Domain.Abstractions.EventStore;

namespace Infraestrutura.ArmazenamentoDeEventos.Repositórios;

public interface IEventStoreRepository
{
    Task AcrescentarEventoAsync(StoreEvent armazenamentoDoEvento, CancellationToken tokenDeCancelamento);
    Task<List<IEvent>> ObterFluxoDeEventosAsync(Guid idDoAgregado, long? versão, CancellationToken tokenDeCancelamento);
    Task ExecutarTransaçãoAsync(Func<CancellationToken, Task> operaçãoAssíncrona, CancellationToken tokenDeCancelamento);
}