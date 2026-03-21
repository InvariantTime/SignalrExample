using Microsoft.AspNetCore.Mvc;
using SignalrExample.Hubs;
using SignalrExample.Objects;
using SignalrExample.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddSingleton<MyObjectRepository>();

var app = builder.Build();

app.MapPost("/api/add", (MyObjectRepository rep, [FromBody]ObjectCreateRequest request) =>
{
    rep.AddObject(new MyObject(request.Name));
});

app.MapPost("/api/change", (MyObjectRepository rep, [FromBody]ObjectChangeNameRequest request) =>
{
    rep.ChangeName(request.Id, request.Name);
});

app.MapHub<TranslationHub>("ws/transition");

app.Run();

record ObjectCreateRequest(string Name);

record ObjectChangeNameRequest(int Id, string Name);