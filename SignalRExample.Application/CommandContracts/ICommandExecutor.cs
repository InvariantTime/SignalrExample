namespace SignalRExample.Application.CommandContracts;

public interface ICommandExecutor
{
    Type CommandType { get; }

    Task ExecuteAsync(object command);
}
