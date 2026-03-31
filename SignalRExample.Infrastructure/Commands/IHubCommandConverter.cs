using SignalrExample.Hubs;

namespace SignalRExample.Infrastructure.Commands;

public interface IHubCommandConverter<T>
{
    static string Type { get; } = string.Empty;

    T Convert(HubCommand raw);
}