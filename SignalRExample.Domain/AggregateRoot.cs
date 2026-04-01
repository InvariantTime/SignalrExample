
namespace SignalRExample.Domain;

public abstract class AggregateRoot<TId> : IDomainEventProvider
{
    private readonly List<IDomainEvent> _events;

    public TId Id { get; }

    public IReadOnlyCollection<IDomainEvent> Events => _events.AsReadOnly();

    protected AggregateRoot(TId id)
    {
        Id = id;

        _events = new List<IDomainEvent>();
    }

    protected void AddEvent(IDomainEvent @event)
    {
        _events.Add(@event);
    }

    public void ClearEvents()
    {
        _events.Clear();
    }
}
