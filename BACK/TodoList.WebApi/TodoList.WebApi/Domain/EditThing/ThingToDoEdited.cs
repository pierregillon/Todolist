using System;
using TodoList.WebApi.Domain.AddThing;

namespace TodoList.WebApi.Domain.EditThing {
    public class ThingToDoEdited : BaseEvent {
        public string NewDescription { get; }

        public ThingToDoEdited(Guid id, string newDescription)
        {
            Id = id;
            NewDescription = newDescription;
        }

    }
}