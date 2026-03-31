
namespace SignalRExample.Domain;

public class SimpleObject
{
    public SimpleObjectId Id { get; }

    public int Value { get; private set; }

    public string Name { get; }

    public SimpleObject(SimpleObjectId id, string name)
    {
        Id = id;
        Name = name;
    }

    public void Increment()
    {
        Value++;
    }

    public void Decrement()
    {
        Value--;
    }
}
