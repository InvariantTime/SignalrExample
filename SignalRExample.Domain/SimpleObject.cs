using SignalRExample.Domain.Events;

namespace SignalRExample.Domain;

public class SimpleObject : AggregateRoot<SimpleObjectId>
{
    public int Value { get; private set; }

    public string Name { get; }

    public SimpleObject(SimpleObjectId id, string name) : base(id)
    {
        Name = name;
    }

    public static SimpleObject Create(SimpleObjectId id, string name)
    {
        var obj = new SimpleObject(id, name);
        obj.AddEvent(new ObjectCreatedEvent(id, name, obj.Value));

        return obj;
    }

    public void Increment()
    {
        Value++;
        AddEvent(new IncrementedEvent(Id, Name, Value));
    }

    public void Decrement()
    {
        Value--;
        AddEvent(new DecrementedEvent(Id, Name, Value));
    }
}
