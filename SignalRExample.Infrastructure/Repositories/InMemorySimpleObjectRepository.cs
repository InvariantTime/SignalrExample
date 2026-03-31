
using SignalRExample.Application.Repositories;
using SignalRExample.Domain;
using System.Collections.Concurrent;

namespace SignalRExample.Infrastructure.Repositories;

public class InMemorySimpleObjectRepository : ISimpleObjectRepository
{
    private readonly ConcurrentDictionary<SimpleObjectId, SimpleObject> _objects;

    public InMemorySimpleObjectRepository()
    {
        _objects = new ConcurrentDictionary<SimpleObjectId, SimpleObject>();
    }

    public bool AddObject(SimpleObject @object)
    {
        return _objects.TryAdd(@object.Id, @object);
    }

    public bool RemoveObject(SimpleObjectId id)
    {
        return _objects.TryRemove(id, out var @object);
    }

    public ICollection<SimpleObject> GetAll()
    {
        return _objects.Values;
    }

    public SimpleObject? GetById(SimpleObjectId id)
    {
        _objects.TryGetValue(id, out var @object);
        return @object;
    }
}
