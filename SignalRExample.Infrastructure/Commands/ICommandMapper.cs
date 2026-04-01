namespace SignalRExample.Infrastructure.Commands;

public interface ICommandMapper
{
    object? Map(ClientCommand command);
}