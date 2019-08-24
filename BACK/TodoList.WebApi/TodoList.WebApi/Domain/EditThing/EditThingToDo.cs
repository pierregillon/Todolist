using System;
using CQRSlite.Commands;

namespace TodoList.WebApi.Domain.EditThing {
    public class EditThingToDo : ICommand
    {
        public Guid Id { get; }
        public string NewDescription { get; }

        public EditThingToDo(Guid id, string newDescription)
        {
            Id = id;
            NewDescription = newDescription;
        }
    }
}