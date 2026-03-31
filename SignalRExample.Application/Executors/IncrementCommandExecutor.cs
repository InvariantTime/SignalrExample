
using SignalRExample.Application.CommandContracts;
using SignalRExample.Application.Commands;
using SignalRExample.Application.Services;

namespace SignalRExample.Application.Executors;

public class IncrementCommandExecutor : CommandExecutor<IncrementCommand>
{
    private readonly ISimpleObjectService _service;

    public IncrementCommandExecutor(ISimpleObjectService service)
    {
        _service = service;
    }

    protected override Task ExecuteAsync(IncrementCommand command)
    {
        _service.Increment(command.Id);
        return Task.CompletedTask;
    }
}
