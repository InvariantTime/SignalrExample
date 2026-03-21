using SignalrExample.Objects;

namespace SignalrExample.Repositories;

public class MyObjectRepository
{
    private readonly Dictionary<int, MyObject> _objects;

    private int _ids;

    public event Action<MyObject, string>? EventChanged;

    public MyObjectRepository()
    {
        _objects = new Dictionary<int, MyObject>();
    }

    public void AddObject(MyObject @object)
    {
        _objects.Add(_ids, @object);
        @object.NameChanged += (value) => OnChangeName(@object, value);
        _ids++;
    }

    public void ChangeName(int id, string name)
    {
        _objects.TryGetValue(id, out var obj);
        obj?.SetName(name);
    }

    private void OnChangeName(MyObject source, string value)
    {
        EventChanged?.Invoke(source, value);
    }
}
