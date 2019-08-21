namespace TodoList.WebApi.Domain.ListItems {
    public class TodoListItem
    {
        public int Id { get; }
        public string Description { get; }

        public TodoListItem(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}