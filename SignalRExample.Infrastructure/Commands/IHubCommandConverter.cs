using SignalrExample.Hubs;
using SignalRExample.Application;

namespace SignalRExample.Infrastructure.Commands;

public interface IHubCommandConverter<T>
{
    ICommand<T> Convert(HubCommand raw);
}
