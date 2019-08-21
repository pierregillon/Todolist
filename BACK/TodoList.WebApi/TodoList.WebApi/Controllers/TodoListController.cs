using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSlite.Queries;
using Microsoft.AspNetCore.Mvc;
using TodoList.WebApi.Domain.ListItems;

namespace TodoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;

        public TodoListController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<TodoListItem>> Get()
        {
            return await _queryProcessor.Query(new ListTodoItemsQuery());
        }
    }
}
