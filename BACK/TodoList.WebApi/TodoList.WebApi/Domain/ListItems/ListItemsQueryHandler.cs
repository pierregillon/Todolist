using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSlite.Queries;
using TodoList.WebApi.Infrastructure.Read;

namespace TodoList.WebApi.Domain.ListItems {
    public class ListItemsQueryHandler : IQueryHandler<ListTodoItemsQuery, IReadOnlyCollection<TodoListItem>>
    {
        private readonly ReadSideDatabase _database;

        public ListItemsQueryHandler(ReadSideDatabase database)
        {
            _database = database;
        }

        public async Task<IReadOnlyCollection<TodoListItem>> Handle(ListTodoItemsQuery x)
        {
            var query = 
                from item in _database.Table<TodoListItemTable>()
                select new TodoListItem(item.Id, item.Description, item.IsDone);

            return await Task.Run(() => query.ToList());
        }
    }
}