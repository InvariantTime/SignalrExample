
using SignalRExample.Application.Commands;
using SignalRExample.Infrastructure.Converters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SignalRExample.Infrastructure.Commands;

public class CommandMapper : ICommandMapper
{
    private readonly JsonSerializerOptions _options;

    public CommandMapper()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new SimpleObjectJsonConverter());
    }

    public object? Map(ClientCommand command)
    {
        var body = command.Body;

        return command.Type switch
        {
            "increment" => body.Deserialize<IncrementCommand>(_options),
            "decrement" => body.Deserialize<DecrementCommand>(_options),
            _ => null
        };
    }
}
