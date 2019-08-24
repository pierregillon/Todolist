using System.Collections.Generic;
using CQRSlite.Commands;
using CQRSlite.Events;
using CQRSlite.Queries;
using StructureMap;
using TodoList.WebApi.Domain.AddThing;
using TodoList.WebApi.Domain.EditThing;
using TodoList.WebApi.Domain.ListItems;
using TodoList.WebApi.Infrastructure;
using TodoList.WebApi.Infrastructure.Read;

namespace TodoList.WebApi.Tests.Utils
{
    public class UnitTestRegistry : Registry
    {
        public UnitTestRegistry()
        {
            // Scans not working in unit tests :( ! Do by hand
            For<IQueryHandler<ListTodoItemsQuery, IReadOnlyCollection<TodoListItem>>>().Use<ListItemsQueryHandler>();
            For<ICommandHandler<AddThingToDo>>().Use<AddThingToDoHandler>();
            For<ICommandHandler<EditThingToDo>>().Use<EditThingToDoHandler>();
            For<IEventHandler<ThingToDoAdded>>().Use<ReadDatabaseFeeder>();
            For<IEventHandler<ThingToDoEdited>>().Use<ReadDatabaseFeeder>();
        }
    }
}
