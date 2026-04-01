using SignalRExample.Application.DTOs;
using SignalRExample.Application.Events;
using SignalRExample.Application.Repositories;
using SignalRExample.Domain;
using System.Threading.Tasks;

namespace SignalRExample.Application.Services;

public class SimpleObjectService : ISimpleObjectService
{
    private readonly ISimpleObjectRepository _repository;
    private readonly IEventBus _bus;

    public SimpleObjectService(ISimpleObjectRepository repository, IEventBus bus)
    {
        _repository = repository;
        _bus = bus;
    }

    public async Task<bool> DecrementAsync(SimpleObjectId id)
    {
        var @object = _repository.GetById(id);

        if (@object == null)
            return false;

        @object.Decrement();

        await _bus.DispatchEventsAsync(@object);

        return true;
    }

    public async Task<bool> IncrementAsync(SimpleObjectId id)
    {
        var @object = _repository.GetById(id);

        if (@object == null)
            return false;

        @object.Increment();

        await _bus.DispatchEventsAsync(@object);

        return true;
    }

    public IEnumerable<SimpleObjectSummary> GetAll()
    {
        return _repository.GetAll()
            .Select(x => new SimpleObjectSummary(x.Id, x.Name, x.Value));
    }

    public async Task<SimpleObjectId> CreateAsync(string name)
    {
        var id = SimpleObjectId.New();
        var obj = SimpleObject.Create(id, name);
        _repository.AddObject(obj);

        await _bus.DispatchEventsAsync(obj);

        return id;
    }
}
