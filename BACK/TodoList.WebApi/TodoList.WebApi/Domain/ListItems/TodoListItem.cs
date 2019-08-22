using System;

namespace TodoList.WebApi.Domain.ListItems {
    public class TodoListItem
    {
        public Guid Id { get; }
        public string Description { get; }

        public TodoListItem(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}