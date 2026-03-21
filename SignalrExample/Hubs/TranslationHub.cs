using Microsoft.AspNetCore.SignalR;
using SignalrExample.Objects;
using SignalrExample.Repositories;

namespace SignalrExample.Hubs;


public interface ITranslationHubClient
{
    Task OnObjectChangedAsync(MyObject obj, string name);
}

public class TranslationHub : Hub<ITranslationHubClient>
{
    private readonly MyObjectRepository _repository;

    public TranslationHub(MyObjectRepository repository)
    {
        _repository = repository;
        _repository.EventChanged += (o, e) => OnNameChangedAsync(o, e);
    }

    private Task OnNameChangedAsync(MyObject obj, string name)
    {
        return Clients.All.OnObjectChangedAsync(obj, name);
    }
}