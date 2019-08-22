using System;

namespace TodoList.WebApi.Domain.AddThing {
    public class ThingToDoAdded : BaseEvent
    {
        public string Description { get; }

        public ThingToDoAdded(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}