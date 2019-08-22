using System;
using System.Linq;
using System.Threading.Tasks;
using CQRSlite.Queries;
using StructureMap;
using TodoList.WebApi.Domain.ListItems;
using TodoList.WebApi.Infrastructure;
using TodoList.WebApi.Tests.Utils;
using Xunit;

namespace TodoList.WebApi.Tests.Unit_Tests {
    public class ListToDoItemsTests
    {
        private readonly ReadSideDatabase _readSideDatabase;
        private readonly IQueryProcessor _queryProcessor;

        public ListToDoItemsTests()
        {
            var container = new Container(x => {
                x.AddRegistry<TodoListRegistry>();
                x.AddRegistry<UnitTestRegistry>();
            });
            _queryProcessor = container.GetInstance<IQueryProcessor>();
            _readSideDatabase = container.GetInstance<ReadSideDatabase>();
        }

        [Fact]
        public async Task list_things_to_do_in_chronological_order()
        {
            // Arrange
            _readSideDatabase.Table<TodoListItemTable>().AddRange(new [] {
                new TodoListItemTable {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    Description = "Call dad"
                },
                new TodoListItemTable {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now.AddSeconds(30),
                    Description = "Call mum"
                }
            });
            // Act
            var todoList = await _queryProcessor.Query(new ListTodoItemsQuery());

            // Assert
            Assert.Equal(2, todoList.Count);
            Assert.Equal("Call dad", todoList.ElementAt(0).Description);
            Assert.Equal("Call mum", todoList.ElementAt(1).Description);
        }
    }
}