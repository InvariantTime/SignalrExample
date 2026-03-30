namespace SignalrExample.Hubs;

public record HubCommand(string Type, object Body);
