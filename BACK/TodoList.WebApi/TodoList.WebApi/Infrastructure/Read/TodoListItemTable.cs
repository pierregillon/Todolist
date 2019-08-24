using System;

namespace TodoList.WebApi.Infrastructure.Read {
    public class TodoListItemTable
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDone { get; set; }
    }
}