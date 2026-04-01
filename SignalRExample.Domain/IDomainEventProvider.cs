namespace SignalRExample.Domain;

public interface IDomainEventProvider
{
    IReadOnlyCollection<IDomainEvent> Events { get; }

    void ClearEvents();
}
