using System.Linq;
using System.Threading.Tasks;
using CQRSlite.Events;
using TodoList.WebApi.Domain.AddThing;
using TodoList.WebApi.Domain.EditThing;
using TodoList.WebApi.Domain.RemoveThing;

namespace TodoList.WebApi.Infrastructure.Read
{
    public class ReadDatabaseFeeder : IEventHandler<ThingToDoAdded>, IEventHandler<ThingToDoEdited>, IEventHandler<ThingToDoDone>
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

        public Task Handle(ThingToDoEdited @event)
        {
            var item = _database.Table<TodoListItemTable>().FirstOrDefault(x => x.Id == @event.Id);
            if (item != null) {
                item.Description = @event.NewDescription;
            }

            return Task.Delay(0);
        }

        public Task Handle(ThingToDoDone @event)
        {
            var item = _database.Table<TodoListItemTable>().FirstOrDefault(x => x.Id == @event.Id);
            if (item != null) {
                item.IsDone = true;
            }

            return Task.Delay(0);
        }
    }
}