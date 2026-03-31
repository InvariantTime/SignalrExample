
using SignalRExample.Domain;

namespace SignalRExample.Application.DTOs;

public record SimpleObjectSummary(SimpleObjectId Id, string Name, int Value);