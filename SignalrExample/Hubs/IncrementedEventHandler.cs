using Microsoft.AspNetCore.SignalR;
using SignalRExample.Application.Events;
using SignalRExample.Domain.Events;
using SignalRExample.Hubs;

namespace SignalrExample.Hubs;

public class IncrementedEventHandler : IDomainEventHandler<IncrementedEvent>
{
    private readonly IHubContext<TranslationHub> _context;

    public IncrementedEventHandler(IHubContext<TranslationHub> context)
    {
        _context = context;
    }

    public Task HandleAsync(IncrementedEvent @event)
    {
        return _context.Clients.All.SendAsync("onEvent", @event.Value);
    }
}
