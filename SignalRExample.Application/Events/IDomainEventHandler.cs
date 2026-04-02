using SignalRExample.Domain;

namespace SignalRExample.Application.Events;

public interface IDomainEventHandler
{
    public Type EventType { get; }
}

public interface IDomainEventHandler<in T> : IDomainEventHandler where T : class, IDomainEvent
{
    Type IDomainEventHandler.EventType => typeof(T);

    Task HandleAsync(T @event);
}