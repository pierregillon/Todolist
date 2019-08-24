using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Events;
using NSubstitute;
using StructureMap;
using TodoList.WebApi.Domain.AddThing;
using TodoList.WebApi.Domain.RemoveThing;
using TodoList.WebApi.Infrastructure;
using TodoList.WebApi.Tests.Utils;
using Xunit;

namespace TodoList.WebApi.Tests.Unit_Tests
{
    public class RemoveThingToDoTests
    {
        private readonly ICommandSender _commandSender;
        private readonly IEventPublisher _eventPublisher;
        private readonly IEventStore _eventStore;

        public RemoveThingToDoTests()
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
        public async Task raise_done()
        {
            // Arrange
            var id = Guid.NewGuid();
            await _eventStore.Save(new[] { new ThingToDoAdded(id, "Call dad to check things ok !") });

            // Action
            await _commandSender.Send(new RemoveThingToDo(id));

            // Assert
            await _eventPublisher.Received(1).Publish(Arg.Is<ThingToDoDone>(x =>
                x.Id == id
            ));
        }
    }
}
