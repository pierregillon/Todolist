using System;

namespace TodoList.WebApi.Domain.ListItems {
    public class TodoListItem
    {
        public Guid Id { get; }
        public string Description { get; }
        public bool IsDone { get; }

        public TodoListItem(Guid id, string description, bool isDone)
        {
            Id = id;
            Description = description;
            IsDone = isDone;
        }
    }
}