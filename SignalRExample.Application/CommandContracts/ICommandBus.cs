namespace SignalRExample.Application.CommandContracts;

public interface ICommandBus
{
    Task ExecuteAsync(object command);
}
