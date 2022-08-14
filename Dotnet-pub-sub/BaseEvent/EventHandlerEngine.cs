using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEvent
{
    public class EventHandlerEngine
    {
        private IServiceProvider _serviceProvider = null;

        private static Dictionary<string, List<Type>> _eventsMapping = new Dictionary<string, List<Type>>();

        public EventHandlerEngine(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Publish<T>(T data) where T : EventBase
        {
            var name = typeof(T).Name;

            if (_eventsMapping.ContainsKey(name))
            {
                foreach (var handler in _eventsMapping[name])
                {
                    var service = (IEventHandler<T>)_serviceProvider.GetService(handler)!;

                    service.Run(data);
                }
            }
        }

        public async Task PublishAsync<T>(T data) where T : EventBase
        {
            var name = typeof(T).Name;

            if (_eventsMapping.ContainsKey(name))
            {
                foreach (var handler in _eventsMapping[name])
                {
                    var service = (IEventHandler<T>)_serviceProvider.GetService(handler)!;

                    await service.RunAsync(data);
                }
            }
        }

        public static void Unsubscribe<T, THanlder>() where T: EventBase where THanlder : IEventHandler<T>
        {
            var name = typeof(T).Name;
            _eventsMapping[name].Remove(typeof(THanlder));

            if (_eventsMapping[name].Count == 0)
            {
                _eventsMapping.Remove(name);
            }
        }

        public static void Subscribe<T, THandler>() where T : EventBase where THandler : IEventHandler<T>
        {
            var name = typeof(T).Name;

            if (!_eventsMapping.ContainsKey(name))
            {
                _eventsMapping.Add(name, new List<Type> { });
            }

            _eventsMapping[name].Add(typeof(THandler));
        }
    }
}
