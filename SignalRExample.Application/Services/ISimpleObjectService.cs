using SignalRExample.Application.DTOs;
using SignalRExample.Domain;

namespace SignalRExample.Application.Services;

public interface ISimpleObjectService
{
    IEnumerable<SimpleObjectSummary> GetAll();

    Task<bool> IncrementAsync(SimpleObjectId id);

    Task<bool> DecrementAsync(SimpleObjectId id);

    Task<SimpleObjectId> CreateAsync(string name);
}
