using System.Collections.Generic;
using CQRSlite.Queries;

namespace TodoList.WebApi.Domain.ListItems
{
    public class ListTodoItemsQuery : IQuery<IReadOnlyCollection<TodoListItem>> { }
}