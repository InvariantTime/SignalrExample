using SignalrExample.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();


var app = builder.Build();

if (app.Environment.IsDevelopment() == true)
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
}

app.MapHub<TranslationHub>("ws/transition");

app.Run();