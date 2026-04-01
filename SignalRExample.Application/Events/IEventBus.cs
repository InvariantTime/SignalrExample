using SignalRExample.Domain;

namespace SignalRExample.Application.Events;

public interface IEventBus
{
    Task SendEventAsync(IDomainEvent @event);
}
