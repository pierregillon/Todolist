using System;
using CQRSlite.Commands;

namespace TodoList.WebApi.Domain.AddThing
{
    public class AddThingToDo : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Description { get; }

        public AddThingToDo(string description)
        {
            Description = description;
        }
    }
}
