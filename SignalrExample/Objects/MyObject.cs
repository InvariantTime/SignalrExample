namespace SignalrExample.Objects;

public class MyObject
{
    public string Name { get; private set; }

    public event Action<string>? NameChanged;

    public MyObject(string name)
    {
        Name = name;
    }

    public void SetName(string name)
    {
        Name = name;
        NameChanged?.Invoke(name);
    }
}