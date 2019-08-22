using System;
using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Events;
using NSubstitute;
using StructureMap;
using TodoList.WebApi.Domain.AddThing;
using TodoList.WebApi.Infrastructure;
using TodoList.WebApi.Tests.Utils;
using Xunit;

namespace TodoList.WebApi.Tests.Unit_Tests
{
    public class AddThingToDoTests
    {
        private readonly ICommandSender _commandSender;
        private readonly IEventPublisher _eventPublisher;

        public AddThingToDoTests()
        {
            var container = new Container(x => {
                x.AddRegistry<TodoListRegistry>();
                x.AddRegistry<UnitTestRegistry>();
            });
            container.Inject(Substitute.For<IEventPublisher>());
            _commandSender = container.GetInstance<ICommandSender>();
            _eventPublisher = container.GetInstance<IEventPublisher>();
        }

        [Fact]
        public async Task add_thing_to_do()
        {
            // Act
            await _commandSender.Send(new AddThingToDo("go to the shop"));

            // Assert
            await _eventPublisher.Received(1).Publish(Arg.Is<ThingToDoAdded>(@event => 
                @event.Description == "go to the shop" &&
                @event.Id != default
            ));
        }
    }
}
