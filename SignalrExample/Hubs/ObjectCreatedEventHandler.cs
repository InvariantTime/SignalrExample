
using Microsoft.AspNetCore.SignalR;
using SignalRExample.Application.Events;
using SignalRExample.Domain.Events;

namespace SignalRExample.Hubs;

public class ObjectCreatedEventHandler : IDomainEventHandler<ObjectCreatedEvent>
{
    private readonly IHubContext<TranslationHub> _context;

    public ObjectCreatedEventHandler(IHubContext<TranslationHub> context)
    {
        _context = context;
    }

    public Task HandleAsync(ObjectCreatedEvent @event)
    {
        return _context.Clients.All.SendAsync("onEvent", @event.Name);
    }
}
