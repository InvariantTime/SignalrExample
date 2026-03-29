using Microsoft.AspNetCore.SignalR;
using SignalrExample.Objects;

namespace SignalrExample.Hubs;

public interface ITranslationHubClient
{
    Task OnObjectChangedAsync(MyObject obj, string name);
}

public class TranslationHub : Hub<ITranslationHubClient>
{
    private readonly ILogger<TranslationHub> _logger;

    public TranslationHub(ILogger<TranslationHub> logger)
    {
        _logger = logger;
    }

    [HubMethodName("executeAction")]
    public Task ExecuteActionAsync(string action)
    {
        _logger.LogInformation("Action execution: {0}", action);

        return Task.CompletedTask;
    }
}