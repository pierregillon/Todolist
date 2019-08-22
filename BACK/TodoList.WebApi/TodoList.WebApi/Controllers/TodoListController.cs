using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Queries;
using Microsoft.AspNetCore.Mvc;
using TodoList.WebApi.Domain.AddThing;
using TodoList.WebApi.Domain.ListItems;

namespace TodoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandSender _commandSender;

        public TodoListController(IQueryProcessor queryProcessor, ICommandSender commandSender)
        {
            _queryProcessor = queryProcessor;
            _commandSender = commandSender;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<TodoListItem>> Get()
        {
            return await _queryProcessor.Query(new ListTodoItemsQuery());
        }

        [HttpPost]
        public async Task Post([FromForm] string description)
        {
            await _commandSender.Send(new AddThingToDo(description));
        }
    }
}
