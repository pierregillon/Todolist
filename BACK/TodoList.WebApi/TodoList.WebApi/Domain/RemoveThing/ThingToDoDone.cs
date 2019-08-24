using System;

namespace TodoList.WebApi.Domain.RemoveThing
{
    public class ThingToDoDone : BaseEvent {
        public ThingToDoDone(Guid id)
        {
            Id = id;
        }
    }
}