using SignalRExample.Application.DTOs;
using SignalRExample.Domain;

namespace SignalRExample.Application.Services;

public interface ISimpleObjectService
{
    IEnumerable<SimpleObjectSummary> GetAll();

    bool Increment(SimpleObjectId id);

    bool Decrement(SimpleObjectId id);

    SimpleObjectId Create(string name);
}
