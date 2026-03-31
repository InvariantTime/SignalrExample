using SignalRExample.Domain;

namespace SignalRExample.Application.Repositories;

public interface ISimpleObjectRepository
{
    bool AddObject(SimpleObject @object);

    bool RemoveObject(SimpleObjectId id);

    SimpleObject? GetById(SimpleObjectId id);

    ICollection<SimpleObject> GetAll();
}