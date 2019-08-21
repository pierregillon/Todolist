using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<TodoListItem>> Get()
        {
            return new[] {
                new TodoListItem(1, "Send a letter to grand ma"),
                new TodoListItem(2, "Update my resume")
            };
        }
    }

    public class TodoListItem {
        public int Id { get; }
        public string Description { get; }

        public TodoListItem(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
