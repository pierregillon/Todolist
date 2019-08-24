using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRSlite.Events;

namespace TodoList.WebApi.Infrastructure.Write
{
    public class InMemoryEventStore : IEventStore
    {
        private readonly IDictionary<Guid, List<IEvent>> _events = new ConcurrentDictionary<Guid, List<IEvent>>();

        public async Task Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var group in events.GroupBy(x => x.Id)) {
                if (_events.ContainsKey(group.Key) == false) {
                    _events.Add(group.Key, new List<IEvent>());
                }

                for (var i = 0; i < group.Count(); i++) {
                    var @event = group.ElementAt(i);
                    @event.Version = _events[group.Key].Count + (i + 1);
                    _events[group.Key].Add(@event);
                }
            }
        }

        public async Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = new CancellationToken())
        {
            await Task.Delay(0, cancellationToken);

            if (_events.TryGetValue(aggregateId, out var events)) {
                return events;
            }

            return Enumerable.Empty<IEvent>();
        }
    }
}