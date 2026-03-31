using SignalrExample.Hubs;
using SignalRExample.Application.CommandContracts;
using SignalRExample.Application.Executors;
using SignalRExample.Application.Repositories;
using SignalRExample.Application.Services;
using SignalRExample.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddSingleton((scope) =>
{
    var executors = scope.GetRequiredService<IEnumerable<ICommandExecutor>>();

    var builder = CommandBus.CreateBuilder();

    foreach (var executor in executors)
        builder.AddExecutor(executor);

    return builder.Build();
});

builder.Services.AddSingleton<ICommandExecutor, IncrementCommandExecutor>();
builder.Services.AddSingleton<ICommandExecutor, DecrementCommandExecutor>();

builder.Services.AddSingleton<ISimpleObjectService, SimpleObjectService>();
builder.Services.AddSingleton<ISimpleObjectRepository, InMemorySimpleObjectRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment() == true)
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
}

app.MapHub<TranslationHub>("ws/transition");

app.Run();