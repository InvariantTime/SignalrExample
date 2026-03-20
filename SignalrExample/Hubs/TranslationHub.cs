using Microsoft.AspNetCore.SignalR;

namespace SignalrExample.Hubs;


public interface ITranslationHubClient
{
    Task OnObjectChangedAsync();
}

public class TranslationHub : Hub<ITranslationHubClient>
{
}