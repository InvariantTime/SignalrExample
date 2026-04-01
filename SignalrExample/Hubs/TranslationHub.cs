using Microsoft.AspNetCore.SignalR;
using SignalRExample.Application.CommandContracts;
using SignalRExample.Infrastructure.Commands;
using System.Text.Json;

namespace SignalRExample.Hubs;

public interface ITranslationHubClient
{
}

public class TranslationHub : Hub<ITranslationHubClient>
{
    private readonly ICommandBus _commands;
    private readonly ICommandMapper _mapper;

    public TranslationHub(ICommandBus commands, ICommandMapper mapper, ILogger<TranslationHub> logger)
    {
        _commands = commands;
        _mapper = mapper;
    }

    [HubMethodName("executeCommand")]
    public Task ExecuteCommandAsync(ClientCommand raw)
    {
        var command = _mapper.Map(raw);

        if (command == null)
            return Task.CompletedTask;//TODOD: notify about invalid command?

        return _commands.ExecuteAsync(command);
    }
}