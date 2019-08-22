using System;

namespace TodoList.WebApi.Domain.ListItems {
    public class TodoListItemTable
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}