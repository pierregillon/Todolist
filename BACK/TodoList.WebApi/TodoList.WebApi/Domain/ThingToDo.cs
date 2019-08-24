using System;
using CQRSlite.Domain;
using TodoList.WebApi.Domain.AddThing;
using TodoList.WebApi.Domain.EditThing;

namespace TodoList.WebApi.Domain {
    public class ThingToDo : AggregateRoot
    {
        private string _description;

        private ThingToDo() { }
        public ThingToDo(Guid id, string description)
        {
            ApplyChange(new ThingToDoAdded(id, description));
        }

        public void Edit(string newDescription)
        {
            ApplyChange(new ThingToDoEdited(Id, newDescription));
        }

        public void Apply(ThingToDoAdded @event)
        {
            Id = @event.Id;
            _description = @event.Description;
        }

        public void Apply(ThingToDoEdited @event)
        {
            _description = @event.NewDescription;
        }

    }
}