
namespace SignalRExample.Domain.Events;

public record ObjectCreatedEvent(SimpleObjectId Id, string Name, int Value) : IDomainEvent;