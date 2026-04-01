
namespace SignalRExample.Domain.Events;

public record DecrementedEvent(SimpleObjectId Id, string Name, int Value) : IDomainEvent;