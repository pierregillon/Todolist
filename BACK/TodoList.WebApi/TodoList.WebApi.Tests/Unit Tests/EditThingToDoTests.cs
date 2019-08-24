using System;
using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Events;
using NSubstitute;
using StructureMap;
using TodoList.WebApi.Domain;
using TodoList.WebApi.Domain.AddThing;
using TodoList.WebApi.Domain.EditThing;
using TodoList.WebApi.Domain.ListItems;
using TodoList.WebApi.Infrastructure;
using TodoList.WebApi.Tests.Utils;
using Xunit;

namespace TodoList.WebApi.Tests.Unit_Tests
{
    public class EditThingToDoTests
    {
        private readonly ICommandSender _commandSender;
        private readonly IEventPublisher _eventPublisher;
        private readonly IEventStore _eventStore;

        public EditThingToDoTests()
        {
            var container = new Container(x => {
                x.AddRegistry<TodoListRegistry>();
                x.AddRegistry<UnitTestRegistry>();
            });
            container.Inject(Substitute.For<IEventPublisher>());
            _commandSender = container.GetInstance<ICommandSender>();
            _eventPublisher = container.GetInstance<IEventPublisher>();
            _eventStore = container.GetInstance<IEventStore>();
        }

        [Fact]
        public async Task throw_error_when_thing_to_do_not_exists()
        {
            // Action
            await Assert.ThrowsAsync<ThingToDoNotFound>(async () =>
                await _commandSender.Send(new EditThingToDo(Guid.NewGuid(), "Call mum to check things ok !")));
        }

        [Fact]
        public async Task raise_item_edited_when_done()
        {
            // Arrange
            var id = Guid.NewGuid();
            await _eventStore.Save(new[] {new ThingToDoAdded(id, "Call dad to check things ok !")});

            // Action
            await _commandSender.Send(new EditThingToDo(id, "Call mum to check things ok !"));

            // Assert
            await _eventPublisher.Received(1).Publish(Arg.Is<ThingToDoEdited>(x =>
                x.Id == id &&
                x.NewDescription == "Call mum to check things ok !"
            ));
        }
    }
}
