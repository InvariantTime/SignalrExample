namespace SignalRExample.Application;

public interface ICommand<T>
{
    Task ExecuteAsync(T payload, CancellationToken cancellation = default);
}