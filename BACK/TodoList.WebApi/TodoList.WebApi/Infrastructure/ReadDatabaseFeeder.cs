using System.Threading.Tasks;
using CQRSlite.Events;
using TodoList.WebApi.Domain.AddThing;
using TodoList.WebApi.Domain.ListItems;

namespace TodoList.WebApi.Infrastructure {
    public class ReadDatabaseFeeder : IEventHandler<ThingToDoAdded>
    {
        private readonly ReadSideDatabase _database;

        public ReadDatabaseFeeder(ReadSideDatabase database)
        {
            _database = database;
        }

        public Task Handle(ThingToDoAdded @event)
        {
            _database.Table<TodoListItemTable>().Add(new TodoListItemTable {
                Id = @event.Id,
                Description = @event.Description,
                CreationDate = @event.TimeStamp.Date
            });

            return Task.Delay(0);
        }
    }
}