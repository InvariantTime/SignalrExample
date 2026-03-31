
using SignalRExample.Application.CommandContracts;
using SignalRExample.Application.Commands;
using SignalRExample.Application.Services;

namespace SignalRExample.Application.Executors;

public class DecrementCommandExecutor : CommandExecutor<DecrementCommand>
{
    private readonly ISimpleObjectService _service;

    public DecrementCommandExecutor(ISimpleObjectService service)
    {
        _service = service;
    }

    protected override Task ExecuteAsync(DecrementCommand command)
    {
        _service.Decrement(command.Id);
        return Task.CompletedTask;
    }
}
