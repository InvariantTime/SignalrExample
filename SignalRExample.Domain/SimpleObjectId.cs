
namespace SignalRExample.Domain;

public readonly record struct SimpleObjectId(Guid Id)
{
    public static readonly SimpleObjectId Empty = new(Guid.Empty);

    public static SimpleObjectId New() => new(Guid.NewGuid());
}