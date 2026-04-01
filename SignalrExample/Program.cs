using SignalRExample.Hubs;
using SignalRExample.Application.CommandContracts;
using SignalRExample.Application.Executors;
using SignalRExample.Application.Repositories;
using SignalRExample.Application.Services;
using SignalRExample.Infrastructure.Commands;
using SignalRExample.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

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

builder.Services.AddSingleton<ICommandMapper, CommandMapper>();

var app = builder.Build();

if (app.Environment.IsDevelopment() == true)
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
}

app.MapPost("api/add", ([FromBody]AddSimpleObjectQuery query, ISimpleObjectService service) =>
{
    var id = service.Create(query.Name);
    return id;
});

app.MapHub<TranslationHub>("ws/translation");

app.Run();

record AddSimpleObjectQuery(string Name);