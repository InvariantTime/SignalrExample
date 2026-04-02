
using SignalRExample.Application.Events;
using SignalRExample.Domain;
using System.Collections.Immutable;

namespace SignalRExample.Infrastructure.Events;

public class EventBus : IEventBus
{
    private readonly ImmutableDictionary<Type, IEnumerable<IDomainEventHandler>> _handlers;
    private readonly EventHandlerActivator _activator;

    public EventBus(IEnumerable<IDomainEventHandler> handlers, EventHandlerActivator activator)
    {
        _activator = activator;
        _handlers = handlers.GroupBy(x => x.EventType)
            .ToImmutableDictionary(x => x.Key, x => x.AsEnumerable());
    }

    public async Task SendEventAsync(IDomainEvent @event)
    {
        var type = @event.GetType();
        _handlers.TryGetValue(type, out var handlers);

        if (handlers == null)
            return;

        var activator = _activator.GetActivator(type);

        if (activator == null)
            return;

        foreach (var handler in handlers)
            await activator.Invoke(handler, @event);

        return;
    }
}
