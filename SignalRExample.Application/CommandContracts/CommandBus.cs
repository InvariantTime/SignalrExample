
using System.Collections.Frozen;

namespace SignalRExample.Application.CommandContracts;

public sealed class CommandBus : ICommandBus
{
    private readonly FrozenDictionary<Type, ICommandExecutor> _executors;

    private CommandBus(IEnumerable<ICommandExecutor> executors)
    {
        _executors = executors.ToFrozenDictionary(x => x.CommandType);
    }

    public Task ExecuteAsync<T>(T command) where T : class
    {
        _executors.TryGetValue(typeof(T), out var executor);

        if (executor == null)
            return Task.CompletedTask;

        return executor.ExecuteAsync(command);
    }

    public static ICommandBusBuilder CreateBuilder()
    {
        return new Builder();
    }

    private class Builder : ICommandBusBuilder
    {
        private readonly List<ICommandExecutor> _executors;

        public Builder()
        {
            _executors = new();
        }

        public void AddExecutor(ICommandExecutor executor)
        {
            _executors.Add(executor);
        }

        public ICommandBus Build()
        {
            return new CommandBus(_executors);
        }
    }
}