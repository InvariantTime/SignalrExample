using SignalRExample.Domain;

namespace SignalRExample.Application.Events;

public interface IDomainEventHandler<T> where T : class, IDomainEvent
{
    void Handle(T @event);
}
