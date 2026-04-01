
using SignalRExample.Domain;

namespace SignalRExample.Application.Events;

public static class EventBusExtensions
{
    public static async Task DispatchEventsAsync(this IEventBus bus, IDomainEventProvider provider)
    {
        var events = provider.Events;

        foreach (var @event in events)
            await bus.SendEventAsync(@event);
    }
}
