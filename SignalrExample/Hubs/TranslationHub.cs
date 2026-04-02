using Microsoft.AspNetCore.SignalR;
using SignalRExample.Application.CommandContracts;
using SignalRExample.Domain;
using SignalRExample.Infrastructure.Commands;

namespace SignalRExample.Hubs;

public class TranslationHub : Hub
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