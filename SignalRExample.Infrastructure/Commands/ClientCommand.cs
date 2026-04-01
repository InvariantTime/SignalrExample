using System.Text.Json;

namespace SignalRExample.Infrastructure.Commands;

public record ClientCommand(string Type, JsonElement Body);
