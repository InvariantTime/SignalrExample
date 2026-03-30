using Microsoft.AspNetCore.SignalR;

namespace SignalrExample.Hubs;

public interface ITranslationHubClient
{
    Task SendEventAsync(HubClientEvent @event);
}

public class TranslationHub : Hub<ITranslationHubClient>
{
    private readonly ILogger<TranslationHub> _logger;

    public TranslationHub(ILogger<TranslationHub> logger)
    {
        _logger = logger;
    }

    [HubMethodName("executeCommand")]
    public Task ExecuteCommandAsync(HubCommand command)
    {
        _logger.LogInformation($"executing {command.Type} with body: {command.Body}");
        return Task.CompletedTask;
    }
}