using SignalRExample.Application.DTOs;
using SignalRExample.Application.Repositories;
using SignalRExample.Domain;

namespace SignalRExample.Application.Services;

public class SimpleObjectService : ISimpleObjectService
{
    private readonly ISimpleObjectRepository _repository;

    public SimpleObjectService(ISimpleObjectRepository repository)
    {
        _repository = repository;
    }

    public bool Decrement(SimpleObjectId id)
    {
        var @object = _repository.GetById(id);

        if (@object == null)
            return false;

        @object.Decrement();

        return true;
    }

    public bool Increment(SimpleObjectId id)
    {
        var @object = _repository.GetById(id);

        if (@object == null)
            return false;

        @object.Increment();

        return true;
    }

    public IEnumerable<SimpleObjectSummary> GetAll()
    {
        return _repository.GetAll()
            .Select(x => new SimpleObjectSummary(x.Id, x.Name, x.Value));
    }

    public SimpleObjectId Create(string name)
    {
        var id = SimpleObjectId.New();
        var obj = new SimpleObject(id, name);
        _repository.AddObject(obj);

        return id;
    }
}
