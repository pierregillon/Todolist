using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSlite.Events;
using TodoList.WebApi.Domain.AddThing;
using TodoList.WebApi.Domain.ListItems;

namespace TodoList.WebApi.Infrastructure
{
    public class ReadSideDatabase : IEventHandler<ThingToDoAdded>
    {
        private readonly IDictionary<Type, object> _tables = new Dictionary<Type, object>();

        public List<T> Table<T>()
        {
            lock (_tables) {
                if (_tables.ContainsKey(typeof(T)) == false) {
                    _tables.Add(typeof(T), new List<T>());
                }

                return (List<T>) _tables[typeof(T)];
            }
        }

        public Task Handle(ThingToDoAdded @event)
        {
            Table<TodoListItemTable>().Add(new TodoListItemTable {
                Id = @event.Id,
                Description = @event.Description,
                CreationDate = @event.TimeStamp.Date
            });

            return Task.Delay(0);
        }
    }
}