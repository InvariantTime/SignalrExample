namespace SignalRExample.Application.CommandContracts;

public interface ICommandBus
{
    Task ExecuteAsync<T>(T command) where T : class;
}
