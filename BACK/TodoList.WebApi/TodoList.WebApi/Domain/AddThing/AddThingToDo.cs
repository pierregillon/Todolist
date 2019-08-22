using CQRSlite.Commands;

namespace TodoList.WebApi.Domain.AddThing
{
    public class AddThingToDo : ICommand
    {
        public string Description { get; }

        public AddThingToDo(string description)
        {
            Description = description;
        }
    }
}
