namespace SignalRExample.Application.CommandContracts;

public interface ICommandBusBuilder
{
    void AddExecutor(ICommandExecutor executor);

    ICommandBus Build();
}
