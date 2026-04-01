
namespace SignalRExample.Domain.Events;

public record IncrementedEvent(SimpleObjectId Id, string Name, int Value) : IDomainEvent;