using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Queries;
using StructureMap;
using TodoList.WebApi.Domain.AddThing;
using TodoList.WebApi.Domain.ListItems;
using TodoList.WebApi.Infrastructure;
using TodoList.WebApi.Tests.Utils;
using Xunit;

namespace TodoList.WebApi.Tests.Acceptance_tests
{
    public class ListTodoListItemsFeature
    {
        private readonly ICommandSender _commandSender;
        private readonly IQueryProcessor _queryProcessor;

        public ListTodoListItemsFeature()
        {
            var container = new Container(x => {
                x.AddRegistry<TodoListRegistry>();
                x.AddRegistry<UnitTestRegistry>();
            });
            _commandSender = container.GetInstance<ICommandSender>();
            _queryProcessor = container.GetInstance<IQueryProcessor>();
        }

        [Fact]
        public async Task get_all_things_to_do()
        {
            await _commandSender.Send(new AddThingToDo("Update my resume"));
            await _commandSender.Send(new AddThingToDo("Go to watch the last Marvel movie"));

            await Task.Delay(200); // Eventually consistency

            var results = await _queryProcessor.Query(new ListTodoItemsQuery());

            Assert.Equal(2, results.Count);
        }
    }
}
