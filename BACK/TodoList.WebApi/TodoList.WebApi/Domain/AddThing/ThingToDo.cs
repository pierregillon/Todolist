using System;
using CQRSlite.Domain;

namespace TodoList.WebApi.Domain.AddThing {
    public class ThingToDo : AggregateRoot
    {
        public ThingToDo(string description)
        {
            ApplyChange(new ThingToDoAdded(Guid.NewGuid(), description));
        }

        public void Apply(ThingToDoAdded @event)
        {
            Id = @event.Id;
        }
    }
}