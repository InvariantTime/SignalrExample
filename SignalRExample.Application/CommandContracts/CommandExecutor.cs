

namespace SignalRExample.Application.CommandContracts;

public abstract class CommandExecutor<T> : ICommandExecutor where T : class
{
    public Type CommandType { get; } = typeof(T);

    public Task ExecuteAsync(object command)
    {
        if (command is not T typed)
            throw new NotImplementedException();

        return ExecuteAsync(typed);
    }

    protected abstract Task ExecuteAsync(T command);
}