
using SignalRExample.Application.Events;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace SignalRExample.Infrastructure.Events;

public delegate Task EventHandlerExecutor(IDomainEventHandler handler, object @event);

public class EventHandlerActivator
{
    private readonly ConcurrentDictionary<Type, EventHandlerExecutor> _activators = new();

    public EventHandlerExecutor? GetActivator(Type eventType)
    {
        return _activators.GetOrAdd(eventType, BuildActivator);
    }

    private static EventHandlerExecutor BuildActivator(Type eventType)
    {
        if (eventType.IsClass == false && eventType.IsInterface == false)
            throw new InvalidCastException("Unable to create non class event handler");

        var handlerParameter = Expression.Parameter(typeof(IDomainEventHandler));
        var eventParameter = Expression.Parameter(typeof(object));

        var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(eventType);

        var handler = Expression.Convert(handlerParameter, handlerType);
        var convertedEvent = Expression.Convert(eventParameter, eventType);

        var method = handlerType.GetMethod(nameof(IDomainEventHandler<>.HandleAsync), BindingFlags.Public | BindingFlags.Instance)!;

        var call = Expression.Call(handler, method, convertedEvent);

        var lambda = Expression.Lambda<EventHandlerExecutor>(call, handlerParameter, eventParameter);

        return lambda.Compile();
    }
}
